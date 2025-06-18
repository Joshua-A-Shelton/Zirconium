#include <gtest/gtest.h>
#include <TestingUtilities.h>

TEST(SingleFileTest, SingleFile)
{
    auto result = TestingUtilities::compile("zrSource/SingleFile/SingleFile.zrproject");
    GTEST_ASSERT_EQ(result.exitCode(), EXIT_SUCCESS);
    ASSERT_STREQ(result.output().c_str(),"Hello, World!");
}
