using System.Diagnostics.CodeAnalysis;

public static class NoNullValues {
    /// <Summary>
    /// A function to test the string (class) values with
    /// This function is used with the String class
    /// </Summary>
    /// <Param name="input">A non-null string to display</Param>
    /// <Exception cref="System.ArgumentNullException">Thrown when the string is null. Used for the examples that should throw exceptions when running the project.</Exception>
    public static void TestString([MaybeNull]string input) {
        if (input == null) {
            throw new ArgumentNullException(nameof(input));
        }
        Console.Out.WriteLine(input);
    }
    /// <Summary>
    /// A function to test the int (struct) values with
    /// This function is used with the Int32 class
    /// </Summary>
    /// <Param name="input">A non-null integer to display</Param>
    /// <Exception cref="System.ArgumentNullException">Thrown when the integer is null. Used for the examples that should throw exceptions when running the project.</Exception>
    public static void TestInt([DisallowNull]int? input) {
        if (!input.HasValue) {
            throw new ArgumentNullException(nameof(input));
        }
        Console.Out.WriteLine("The integer is: {0}", input.Value);
    }
}