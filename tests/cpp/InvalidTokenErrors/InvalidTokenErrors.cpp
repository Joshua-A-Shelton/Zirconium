#include <gtest/gtest.h>
#include <TestingUtilities.h>

TEST(InvalidTokenErrorsTest,InvalidTokenErrors)
{
    auto result = TestingUtilities::compile("zrSource/InvalidTokenErrors/InvalidTokenErrors.zrproject");
    GTEST_ASSERT_EQ(result.exitCode(), EXIT_FAILURE);
    auto output = result.compilerMessages();

    int errorCount = 0;
    std::vector<zr::TextSpan> invalidLocations
    {
        zr::TextSpan(3,5,3,7),
        zr::TextSpan(3,10,3,12),
        zr::TextSpan(4,19,4,20),
        zr::TextSpan(7,1,7,4),
        zr::TextSpan(7,5,7,6),
    };
    for (auto i=0; i<output.size(); i++)
    {
        auto& message = output[i];
        if (message.id() == zr::INVALID_TOKEN)
        {
            ++errorCount;
            std::erase_if(invalidLocations,[&](zr::TextSpan span){return message.span()==span;});
        }
    }
    GTEST_ASSERT_EQ(invalidLocations.size(), 0);
    GTEST_ASSERT_EQ(errorCount, 5);

}
