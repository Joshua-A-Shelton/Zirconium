cmake_minimum_required(VERSION 3.30)
project(Zirconium)

set(CMAKE_CXX_STANDARD 20)
include(FetchContent)

find_package(Boost REQUIRED COMPONENTS program_options)
FetchContent_Declare(
        nlohmann_json
        URL https://github.com/nlohmann/json/releases/download/v3.12.0/json.tar.xz
)
FetchContent_MakeAvailable(nlohmann_json)

add_library(zr
        src/zr/Messages/CompilerMessage.cpp
        src/zr/Messages/CompilerMessage.h
        src/zr/TextLocation.cpp
        src/zr/TextLocation.h
        src/zr/Parsing/TokenStream.cpp
        src/zr/Parsing/TokenStream.h
        src/zr/Parsing/TokenFinder.cpp
        src/zr/Parsing/TokenFinder.h
        src/zr/CompilerRunData.cpp
        src/zr/CompilerRunData.h
        src/zr/ProjectSettings.cpp
        src/zr/ProjectSettings.h
        src/zr/Parsing/Token.cpp
        src/zr/Parsing/Token.h
)

target_link_libraries(zr PRIVATE nlohmann_json::nlohmann_json)

add_executable(zrc compiler/Main.cpp)
target_include_directories(zrc PUBLIC src)
target_link_libraries(zrc PRIVATE Boost::program_options zr)


if(PROJECT_IS_TOP_LEVEL)
    FetchContent_Declare(
            googletest
            URL https://github.com/google/googletest/archive/03597a01ee50ed33e9dfd640b249b4be3799d395.zip
    )
    set(gtest_force_shared_crt ON CACHE BOOL "" FORCE)
    FetchContent_MakeAvailable(googletest)

    add_executable(ZirconiumTests
            tests/cpp/SingleFile/SingleFile.cpp
            tests/cpp/TestingUtilities.cpp
            tests/cpp/TestingUtilities.h
            tests/cpp/CompileResult.cpp
            tests/cpp/CompileResult.h
            tests/cpp/InternalAccessErrors/InternalAccessErrors.cpp
            tests/cpp/InvalidTokenErrors/InvalidTokenErrors.cpp
            tests/cpp/Class/Class.cpp
    )

    target_include_directories(ZirconiumTests PRIVATE tests/cpp src)
    target_link_libraries(ZirconiumTests GTest::gtest_main zr)
    include(GoogleTest)
    gtest_discover_tests(ZirconiumTests)

    add_dependencies(ZirconiumTests zrc)

    file(COPY ${CMAKE_CURRENT_SOURCE_DIR}/tests/zrSource DESTINATION ${CMAKE_CURRENT_BINARY_DIR})
endif()