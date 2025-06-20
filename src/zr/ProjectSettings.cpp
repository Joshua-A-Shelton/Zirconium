#include "ProjectSettings.h"

#include <fstream>
#include <iostream>
#include <nlohmann/json.hpp>
namespace zr
{
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
            std::string outputType = data["output"].get<std::string>();
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
            auto compileFiles = data["compileFiles"];
            auto root = filePath.parent_path();
            for (const auto& compileFile : compileFiles)
            {
                _sourceFiles.push_back(root.string()+"/"+ compileFile.get<std::string>());
            }
        }
        catch (nlohmann::json::parse_error& pe)
        {
            throw std::runtime_error("Malformed JSON in project file "+ filePath.string());
        }

    }

    const std::vector<std::filesystem::path>& ProjectSettings::sourceFiles()
    {
        return _sourceFiles;
    }

    ProjectType ProjectSettings::projectType() const
    {
        return _projectType;
    }
} // zr
