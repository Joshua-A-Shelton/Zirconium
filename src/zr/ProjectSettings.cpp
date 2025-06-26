#include "ProjectSettings.h"
#include <fstream>
#include <iostream>
namespace zr
{
    Target::Target(const nlohmann::basic_json<>& json, const std::filesystem::path& filePath)
    {
        std::string outputType = json["output"].get<std::string>();
        if (outputType == "Executable")
        {
            _projectType = ProjectType::EXECUTABLE;
        }
        else if (outputType == "Static Library")
        {
            _projectType = ProjectType::STATIC_LIBARY;
        }
        else if (outputType == "Dynamic Library")
        {
            _projectType = ProjectType::DYNAMIC_LIBRARY;
        }
        else
        {
            throw std::runtime_error("Unknown output type in: "+filePath.string());
        }
        auto compileFiles = json["compileFiles"];
        auto root = filePath.parent_path();
        for (const auto& compileFile : compileFiles)
        {
            _sourceFiles.push_back(root.string()+"/"+ compileFile.get<std::string>());
        }
    }

    const std::string& Target::name() const
    {
        return _name;
    }

    const std::vector<std::filesystem::path>& Target::sourceFiles() const
    {
        return _sourceFiles;
    }

    ProjectType Target::projectType() const
    {
        return _projectType;
    }

    ProjectSettings::ProjectSettings(const std::filesystem::path& filePath)
    {
        try
        {
            std::ifstream file(filePath);
            std::stringstream fileBuffer;
            fileBuffer << file.rdbuf();
            const std::string fileText = fileBuffer.str();
            file.close();
            auto data = nlohmann::json::parse(fileText);
            auto targets = data["targets"];
            for (const auto& target : targets)
            {
                _targets.emplace_back(target,filePath);
            }

        }
        catch (nlohmann::json::parse_error& pe)
        {
            throw std::runtime_error("Malformed JSON in project file "+ filePath.string());
        }

    }

    const std::vector<Target>& ProjectSettings::targets() const
    {
        return _targets;
    }
} // zr
