// See https://aka.ms/new-console-template for more information

using CSAssignment2;

CopyAnArray copyAnArray=new CopyAnArray();
copyAnArray.Solution();

ManageAListOfElements manageAListOfElements=new ManageAListOfElements();
manageAListOfElements.Solution();

CalculatesAllPrimeNumbers.FindPrimesInRange(1,100);

FindsTheLongestSequenceOfEqualElements findsTheLongestSequenceOfEqualElements=new FindsTheLongestSequenceOfEqualElements();
findsTheLongestSequenceOfEqualElements.Solution();

ArrayRotation arrayRotation=new ArrayRotation();
arrayRotation.Solution();

MostFrequentNumber mostFrequentNumber=new MostFrequentNumber();
mostFrequentNumber.Solution();

ReversString reversString=new ReversString();
reversString.Solution1();
reversString.Solution2();

string sentence1 = "C# is not C++, and PHP is not Delphi!";
string reversedSentence1 = ReverseSentenceKeepingPunctuation.Solution(sentence1);
Console.WriteLine(reversedSentence1);

string sentence2 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/.";
string reversedSentence2 = ReverseSentenceKeepingPunctuation.Solution(sentence2);
Console.WriteLine(reversedSentence2);

string input = "Hi,exe? ABBA! Hog fully a string: ExE. Bob a, ABBA, exe, ExE";
var palindromes = Palindromes.ExtractAndSortPalindromes(input);
Console.WriteLine(string.Join(", ", palindromes));

Parser parser = new Parser();
// Test the parser with different URLs
parser.ParseURL("https://www.apple.com/iphone");
parser.ParseURL("ftp://www.example.com/employee");
parser.ParseURL("https://google.com");
parser.ParseURL("www.apple.com");