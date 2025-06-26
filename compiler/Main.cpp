#include <filesystem>
#include <iostream>
#include <boost/program_options.hpp>

#include "zr/ProjectSettings.h"
#include "zr/Parsing/TokenStream.h"
namespace po = boost::program_options;

int main(int arc, char** argv)
{
    po::options_description desc("Allowed options");
    desc.add_options()
    ("help,h", "produce help message")
    ("project,p", po::value<std::string>(), "path to project file")
    ("target,t", po::value<std::string>()->default_value("all"), "target(s) binary in project to build")
    ("arch,a", po::value<std::string>()->default_value("host"), "output architecture of build")
    ;

    po::positional_options_description positional;
    positional.add("project", 1);

    po::variables_map vm;
    po::store(po::command_line_parser(arc, argv)
        .options(desc)
        .positional(positional)
        .run(),vm);
    po::notify(vm);

    if (vm.count("help"))
    {
        std::cout << desc << std::endl;
        return EXIT_SUCCESS;
    }

    std::filesystem::path projectPath = vm["project"].as<std::string>();
    zr::ProjectSettings settings;
    try
    {
        settings = zr::ProjectSettings(projectPath);
    }
    catch (const std::exception& e)
    {
        std::cout << e.what() << std::endl;
        return EXIT_FAILURE;
    }

    std::cout << "building "<< projectPath.filename() << std::endl;

    zr::CompilerRunData runData;
    //get targets
    std::vector<std::string> targets;
    if (vm.count("target") && vm["target"].as<std::string>() != "all")
    {
        std::string targetString = vm["target"].as<std::string>();
        std::stringstream ss(targetString);
        std::string segment;
        while (std::getline(ss,segment,','))
        {
            bool foundTarget = false;
            for (auto i=0; i< settings.targets().size(); i++)
            {
                if (settings.targets()[i].name() == segment)
                {
                    foundTarget = true;
                    targets.push_back(segment);
                }
            }
            if (!foundTarget)
            {
                std::cout << "invalid target "<< segment << std::endl;
                return EXIT_FAILURE;
            }
        }
    }
    else
    {
        for (auto& target: settings.targets())
        {
            targets.push_back(target.name());
        }
    }

    for (auto& target: settings.targets())
    {
        if (std::find(targets.begin(),targets.end(),target.name()) != targets.end())
        {
            for (auto& file: target.sourceFiles())
            {
                zr::parsing::TokenStream tokens(file,runData);
                //TODO: parse the token streams into data structures
            }
        }
    }


    bool error = false;
    for (auto& message: runData.messages())
    {
        std::cout<< message.toString() << "\n";
        if (message.type() == zr::ERROR)
        {
            error = true;
        }
    }
    if (error)
    {
        return EXIT_FAILURE;
    }


    return EXIT_SUCCESS;
}
