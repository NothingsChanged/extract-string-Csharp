/* For example:
   string Value = "<a>SomeText</a>";
   Extract extractStr = new Extract(Value, "<a>", "</a>");
   Console.Write(extractStr.SeparatedValue);
   out: SomeText
*/
namespace Test
{
    class Extract
    {
        public string[] SeparatedValue { get; set; }
        public Extract(string Input, string Left, string Right)
        {
            SeparatedValue = ExtractString(Input, Left, Right);
        }
        public static string[] ExtractString(string Input, string Left, string Right)
        {
            //Separates with Right and clears the array of characters ""
            string[] SeparatedInput = GetCleanArray( Input.Split(Right) );

            //If the Left argument does not exist in the line, it will equal ""
            for (int index = 0; index < SeparatedInput.Length; index++)
                if( ( SeparatedInput[index].IndexOf(Left) ) == -1 )
                    SeparatedInput[index] = "";
            //Clears the array of characters ""
            string[] CleanSeparatedArray = GetCleanArray(SeparatedInput);

            //Cut Left
            for (int index = 0; index < CleanSeparatedArray.Length; index++)
                CleanSeparatedArray[index] = CleanSeparatedArray[index].Split(Left)[1];

            return CleanSeparatedArray;
        }   
        private static string[] GetCleanArray(string[] Array)
        {
            //Get the length of the new cleared array
            int CleanedLength = 0;
            for (int index = 0; index < Array.Length; index++)
                if(Array[index] != "")
                    CleanedLength++;
            //Clear
            string[] CleanedValue = new string[CleanedLength];
            int CleanedIndex = 0;
            for (int index = 0; index < Array.Length; index++) 
                if(Array[index] != "")
                {
                    CleanedValue[CleanedIndex] = Array[index];
                    CleanedIndex++;
                }
            return CleanedValue;
        }
    }
}
