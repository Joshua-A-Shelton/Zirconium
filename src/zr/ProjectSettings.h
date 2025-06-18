#ifndef ZIRCONIUM_PROJECTSETTINGS_H
#define ZIRCONIUM_PROJECTSETTINGS_H
#include <filesystem>
#include <vector>

namespace zr
{
    enum ProjectType
    {
        EXECUTABLE,
        STATIC_LIBARY,
        DYNAMIC_LIBRARY,
    };

    class ProjectSettings
    {
    public:
        ProjectSettings()=default;
        ProjectSettings(const std::filesystem::path& filePath);
        const std::vector<std::filesystem::path>& sourceFiles();
        ProjectType projectType() const;
    private:
        std::vector<std::filesystem::path> _sourceFiles;
        ProjectType _projectType = EXECUTABLE;
    };
} // zr

#endif //ZIRCONIUM_PROJECTSETTINGS_H
