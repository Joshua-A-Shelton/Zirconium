#include <gtest/gtest.h>
#include <TestingUtilities.h>

TEST(InternalAccessErrorsTest,InternalAccessErrors)
{
    auto result = TestingUtilities::compile("zrSource/InternalAccessErrors/InternalAccessErrors.zrproject");
    GTEST_ASSERT_EQ(result.exitCode(), EXIT_FAILURE);
    auto output = result.compilerMessages();

    //finish implementation
    GTEST_FAIL();

}
