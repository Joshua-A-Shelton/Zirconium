#include <gtest/gtest.h>
#include <TestingUtilities.h>

TEST(ClassTest,Class)
{
    auto result = TestingUtilities::compile("zrSource/Class/Class.zrproject");
    GTEST_ASSERT_EQ(result.exitCode(), EXIT_SUCCESS);

    //implement test
    GTEST_FAIL();
}

