#ifndef ZIRCONIUM_PROJECTSETTINGS_H
#define ZIRCONIUM_PROJECTSETTINGS_H
#include <filesystem>
#include <vector>
#include <nlohmann/json.hpp>

namespace zr
{
    enum ProjectType
    {
        EXECUTABLE,
        STATIC_LIBARY,
        DYNAMIC_LIBRARY,
    };

    class Target
    {
    private:
        std::string _name;
        std::vector<std::filesystem::path> _sourceFiles;
        ProjectType _projectType = ProjectType::EXECUTABLE;
    public:
        Target(const nlohmann::basic_json<>& json, const std::filesystem::path& filePath);
        const std::string& name() const;
        const std::vector<std::filesystem::path>& sourceFiles() const;
        ProjectType projectType() const;
    };

    class ProjectSettings
    {
    public:
        ProjectSettings()=default;
        ProjectSettings(const std::filesystem::path& filePath);
        const std::vector<Target>& targets() const;
    private:
        std::vector<Target> _targets;
    };
} // zr

#endif //ZIRCONIUM_PROJECTSETTINGS_H
