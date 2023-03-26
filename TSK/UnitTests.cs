using NUnit.Framework;
using NUnit.Framework.Constraints;
using ViewLayer.Controllers;
using System.IO;
using System;

namespace NUnitTests
{
    internal class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] _questionPoints =
{
            new object[] { "tstest", "i16484017616449649", 5, true },//1 radek - vse cisla
            new object[] { "tstest", "i164840810384652", 14, true },//vice radku - vse cisla
            new object[] { "nonexistentTest", "nonexistentItem", 0, false },//neexistujici test
            new object[] { "tstest", "i16484019989003650", 0, false },//1 radek - vse N/A
            new object[] { "tstest", "i16484076234573651", 4, false },//vice radku - kombinace
            new object[] { "tstest", "i16484004241351648", 0, false }//vice radku - vse N/A
        };

        [Test]//Sedí počet bodů?
        [TestCaseSource(nameof(_questionPoints))]
        public void QuestionPointsTest(string testNameIdentifier, string itemNumberIdentifier, int expectedPoints, bool expectedDetermination)
        {
            TestController testController = new TestController();
            var result = testController.GetQuestionPoints(testNameIdentifier, itemNumberIdentifier);
            Assert.That((result.Item1, result.Item2), Is.EqualTo((expectedPoints, expectedDetermination)));
        }

        private static readonly object[] _itemParameters =
        {
            new object[] { "nonexistenttest", "i16445870414674424", "i164458888823442", "item-4", "20220211154304", "i1634296556634024",
                "RESPONSE", "3", 4, 1, 0, 1, false },//neexistujici test - vyjimka
            new object[] { "postestcopy", "i16445870414674424", "i164458888823442", "item-4", "nonexistentdeliveryexecutionidentifier", "i1634296556634024",
                "RESPONSE", "3", 4, 1, 0, 1, false },//neexistujici soubor vysledku - vyjimka
            new object[] { "postestcopy", "i16445870414674424", "i164458888823442", "item-4", "20220211154304", "i1634296556634024",
                null, null, null, null, null, null, false },//studentsPoints je null
            new object[] { "postestcopy", "i16445870414674424", "i164458888823442", "item-4", "20220211154304", "i1634296556634024",
                "RESPONSE", "notanumber", 4, 1, 0, 1, false },//isDecimal je false
            new object[] { "tstest", "i16484086222594654", "i16484004241351648", "item-1", "20220406151841", "i1634296556634024",
                "RESPONSE", "3", 4, 1, 0, 0, false },//questionPointsDetermined je 0
            new object[] { "postestcopy", "i16445870414674424", "i164458888823442", "item-4", "20220211154304", "i1634296556634024",
                "RESPONSE", "3", 4, 1, 0, 1, true },//amountOfSubitems je 1
            new object[] { "postestcopy", "i16445870414674424", "i16445890213918443", "item-5", "20220211154304", "i1634296556634024",
                "RESPONSE", "4", 5, 2, 0, 1, true },//amountOfSubitems > 1; subitemIndex = 0
            new object[] { "postestcopy", "i16445870414674424", "i16445890213918443", "item-5", "20220211154304", "i1634296556634024",
                "RESPONSE_1", "4", 5, 2, 1, 1, true },//amountOfSubitems > 1; subitemIndex = 1
        };

        [Test]//Funguje změna počtu bodů u vyřešeného testu správně?
        [TestCaseSource(nameof(_itemParameters))]
        public void ItemManagementTest(string testNameIdentifier, string testNumberIdentifier, string itemNumberIdentifier, string itemNameIdentifier, string deliveryExecutionIdentifier,
            string studentIdentifier, string selectedSubitem, string studentsPoints, int subquestionMaxPoints, int amountOfSubitems, int subitemIndex, int questionPointsDetermined, bool changeStudentsPoints)
        {
            HomeController homeController = new HomeController();
            if (testNameIdentifier == "nonexistenttest" || deliveryExecutionIdentifier == "nonexistentdeliveryexecutionidentifier")
            {
                ActualValueDelegate<object> testDelegate = () => homeController.ManageSolvedItem(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, deliveryExecutionIdentifier, studentIdentifier, selectedSubitem, studentsPoints, subquestionMaxPoints, amountOfSubitems, subitemIndex, questionPointsDetermined);
                Assert.That(testDelegate, Throws.TypeOf<DirectoryNotFoundException>().Or.TypeOf<FileNotFoundException>());
            }
            else
            {
                double fileOldContent = 0;
                string[] oldResultsFileLines = File.ReadAllLines("C:\\xampp\\exported\\results\\" + testNameIdentifier + "\\delivery_execution_" + deliveryExecutionIdentifier + "Results.txt");
                for (int i = 0; i < oldResultsFileLines.Length; i++)
                {
                    string[] splitResultsFileLineBySemicolon = oldResultsFileLines[i].Split(";");
                    if (splitResultsFileLineBySemicolon[0] == itemNameIdentifier)
                    {
                        fileOldContent = double.Parse(splitResultsFileLineBySemicolon[subitemIndex + 1]);
                    }
                }
                homeController.ManageSolvedItem(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, deliveryExecutionIdentifier, studentIdentifier, 
                    selectedSubitem, studentsPoints, subquestionMaxPoints, amountOfSubitems, subitemIndex, questionPointsDetermined);

                double fileNewContent = 0;
                string[] newResultsFileLines = File.ReadAllLines("C:\\xampp\\exported\\results\\" + testNameIdentifier + "\\delivery_execution_" + deliveryExecutionIdentifier + "Results.txt");
                for (int i = 0; i < newResultsFileLines.Length; i++)
                {
                    string[] splitResultsFileLineBySemicolon = newResultsFileLines[i].Split(";");
                    if (splitResultsFileLineBySemicolon[0] == itemNameIdentifier)
                    {
                        fileNewContent = double.Parse(splitResultsFileLineBySemicolon[subitemIndex + 1]);
                    }
                }
                Console.WriteLine("asd: " + fileOldContent + ", " + fileNewContent);
                if (changeStudentsPoints)
                {
                    Assert.That(fileNewContent.Equals(double.Parse(studentsPoints)));
                    
                    //Obnova původních dat
                    homeController.ManageSolvedItem(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, deliveryExecutionIdentifier, studentIdentifier,
                        selectedSubitem, fileOldContent.ToString(), subquestionMaxPoints, amountOfSubitems, subitemIndex, questionPointsDetermined);
                }
                else
                {
                    Assert.That(fileOldContent.Equals(fileNewContent));
                }
            }
        }

        private static readonly object[] _subquestionList =
        {
            new object[] { "RESPONSE", 1, 5, "postest", "i164458888823442" },//jediny typ otazky u ktereho ocekavame possibleAnswerList.Count == 0
            new object[] { "RESPONSE", 1, 7, "prtest", "i1646384183554540" },//questionType == 7
            new object[] { "RESPONSE", 1, 4, "prtest", "i16463847665905541" },//questionType == 4, amountOfSubitems == 1
            new object[] { "RESPONSE_1", 2, 4, "prtest", "i16463849633151542" },//questionType == 4, amountOfSubitems > 1
            new object[] { "RESPONSE", 1, 10, "prtest", "i16463855153387543" },//questionType == 10, amountOfSubitems == 1
            new object[] { "RESPONSE", 2, 10, "prtest", "i16463857907220544" },//questionType == 10, amountOfSubitems > 1
            new object[] { "RESPONSE", 2, 6, "prtest", "i16463860664434545" },//questionType == 6 (else), amountOfSubitems > 1
            new object[] { "RESPONSE", 1, 1, "prtest", "i16463863126026546" },//questionType == 1 (else), amountOfSubitems == 1
            new object[] { "RESPONSE", 2, 9, "prtest", "i16463876861201549" },//questionType == 9 (else), amountOfSubitems > 1
            new object[] { "unexistingresponse", 1, 9, "prtest", "i16463876861201549" },//neexistujici id - vybere jedine v souboru
            new object[] { "unexistingresponse", 2, 9, "prtest", "i16463876861201549" },//neexistujici id a amountOfSubitems == 1 - nenajde zadne odpovedi
            new object[] { "RESPONSE", 2, 9, "unexistingtest", "unexistingitem" },//neexistujici test/item - vrati vyjimku
        };

        [Test]//Má každá otázka alespoň jednu možnou odpověď?
        [TestCaseSource(nameof(_subquestionList))]
        public void PossibleAnswerAmountTest(string selectedResponseIdentifier, int amountOfSubitems, int questionType, string testNameIdentifier, string itemNumberIdentifier)
        {
            ItemController itemController = new ItemController();

            if (testNameIdentifier == "unexistingtest" || itemNumberIdentifier == "unexistingitem")
            {
                ActualValueDelegate<object> testDelegate = () => itemController.GetPossibleAnswerList(selectedResponseIdentifier, amountOfSubitems,
                    questionType, testNameIdentifier, itemNumberIdentifier).Item1.Count;
                Assert.That(testDelegate, Throws.TypeOf<DirectoryNotFoundException>().Or.TypeOf<FileNotFoundException>());
            }
            else
            {
                if (questionType == 5 || (selectedResponseIdentifier == "unexistingresponse" && amountOfSubitems > 1))
                {
                    Assert.AreEqual(itemController.GetPossibleAnswerList(selectedResponseIdentifier, amountOfSubitems, questionType, testNameIdentifier, itemNumberIdentifier).Item1.Count, 0);
                }
                else
                {
                    Assert.That(itemController.GetPossibleAnswerList(selectedResponseIdentifier, amountOfSubitems, questionType, testNameIdentifier, itemNumberIdentifier).Item1.Count, Is.GreaterThan(0));
                }
            }
        }
    }
}
