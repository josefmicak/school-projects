using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using ViewLayer.Controllers;
using Common;

namespace NUnitTests
{
    [TestFixture]
    public class AutomatedTests
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver("../../../../");
            js = (IJavaScriptExecutor)driver;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        private static readonly object[] _resultPointsTestSource =
{
            new object[] { 4.01, 2, 2, 0, null},
            new object[] { 4, 2, 2, 0, "Počet získaných bodů byl u studenta úspěšně upraven."},
            new object[] { -4, 2, 2, 0, "Počet získaných bodů byl u studenta úspěšně upraven."},
            new object[] { -4.01, 2, 2, 0, null },
            new object[] { 1, 8, 0, 0, "Chyba: není možné upravit počet bodů studenta. Nejprve je nutné určit počet obdržených bodů za otázku." }
        };

        [Test]//Funguje změna počtu bodů u vyřešeného testu správně?
        [TestCaseSource(nameof(_resultPointsTestSource))]
        public void ResultPointsTest(double awardedPoints, int selectedTestIndex, int selectedItemIndex, int selectedSubitemIndex, string expectedOutcome)
        {
            Settings.CustomRole = 1;
            bool questionPointsDetermined = true;
            driver.Navigate().GoToUrl("https://localhost:7057/Home/TeacherMenu");
            driver.FindElement(By.Id("manageSolvedTestListBtn")).Click();

            string selectedTestButton = "manageSolvedTestBtn_" + selectedTestIndex.ToString();
            driver.FindElement(By.Id(selectedTestButton)).Click();

            //Sběr dat o pokusu (test) pro pozdější obnovu dat
            string testNameIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(1) > td")).Text;
            string testNumberIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(2) > td")).Text;
            string deliveryExecutionIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(4) tr:nth-child(1) > td")).Text;
            string studentIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(4) tr:nth-child(5) > td")).Text;

            var oldTestPoints = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(5) > td")).Text;
            string[] oldTestPointsStringValue = oldTestPoints.Split("/");
            bool isNumber = double.TryParse(oldTestPointsStringValue[0], out _);
            if(!isNumber)
            {
                questionPointsDetermined = false;
            }
            // Assert.That(isNumber, Is.True);
            int oldTestPointsValue = 0;
            if(isNumber)
            {
                oldTestPointsValue = int.Parse(oldTestPointsStringValue[0]);
            }

            string selectedQuestionTestPointsLabel = "tr:nth-child(" + (selectedItemIndex + 2).ToString() + ") > td:nth-child(5)";
            var oldQuestionTestPoints = driver.FindElement(By.CssSelector(selectedQuestionTestPointsLabel)).Text;
            string[] oldQuestionTestPointsStringValue = oldQuestionTestPoints.Split("/");
            isNumber = double.TryParse(oldQuestionTestPointsStringValue[0], out _);
            if (!isNumber)
            {
                questionPointsDetermined = false;
            }
            //   Assert.That(isNumber, Is.True);
            int oldQuestionTestPointsValue = 0;
            if (isNumber)
            {
                oldQuestionTestPointsValue = int.Parse(oldQuestionTestPointsStringValue[0]);
            }

            string selectedItemButton = "manageSolvedItemBtn_" + selectedItemIndex.ToString();
            driver.FindElement(By.Id(selectedItemButton)).Click();

            //Sběr dat o pokusu (otázka) pro pozdější obnovu dat
            string itemNumberIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(2) > td")).Text;
            string itemNameIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(1) > td")).Text;
            string selectedSubitem = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(2) > td")).Text;
            string amountOfSubitems = driver.FindElement(By.CssSelector("tr:nth-child(5) > td:nth-child(2)")).Text;

            var oldInputPoints = driver.FindElement(By.Id("studentsPointsLabel"));
            int oldInputPointsValue = int.Parse(oldInputPoints.GetAttribute("value"));

            var oldQuestionPoints = driver.FindElement(By.CssSelector("tr:nth-child(6) > td")).Text;
            string[] oldQuestionPointsStringValue = oldQuestionPoints.Split("/");
            int oldQuestionPointsValue = 0;
            if(questionPointsDetermined)
            {
                oldQuestionPointsValue = int.Parse(oldQuestionPointsStringValue[0]);
            }

            var oldSubquestionPoints = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(3) > td")).Text;
            string[] oldSubquestionPointsStringValue = oldSubquestionPoints.Split("/");
            int oldSubquestionPointsValue = 0;
            int subquestionMaxPoints = 0;
            if (questionPointsDetermined)
            {
                oldSubquestionPointsValue = int.Parse(oldSubquestionPointsStringValue[0]);
                subquestionMaxPoints = int.Parse(oldSubquestionPointsStringValue[1]);
            }

            var oldAnswerPoints = driver.FindElement(By.CssSelector(".correct:nth-child(2)")).Text;
            string[] oldAnswerPointsStringValue = oldAnswerPoints.Split("/");
            int oldAnswerPointsValue = int.Parse(oldAnswerPointsStringValue[0]);

            oldInputPoints.Clear();
            driver.FindElement(By.Id("studentsPointsLabel")).SendKeys((awardedPoints).ToString());
            driver.FindElement(By.Id("setStudentsPointsBtn")).Click();

            var newInputPoints = driver.FindElement(By.Id("studentsPointsLabel"));
            int newInputPointsValue = int.Parse(newInputPoints.GetAttribute("value"));

            var newQuestionPoints = driver.FindElement(By.CssSelector("tr:nth-child(6) > td")).Text;
            string[] newQuestionPointsStringValue = newQuestionPoints.Split("/");
            int newQuestionPointsValue = 0;
            if (questionPointsDetermined)
            {
                newQuestionPointsValue = int.Parse(newQuestionPointsStringValue[0]);
            }

            var newSubquestionPoints = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(3) > td")).Text;
            string[] newSubquestionPointsStringValue = newSubquestionPoints.Split("/");
            int newSubquestionPointsValue = 0;
            if (questionPointsDetermined)
            {
                newSubquestionPointsValue = int.Parse(newSubquestionPointsStringValue[0]);
            }

            var newAnswerPoints = driver.FindElement(By.CssSelector(".correct:nth-child(2)")).Text;
            string[] newAnswerPointsStringValue = newAnswerPoints.Split("/");
            int newAnswerPointsValue = int.Parse(newAnswerPointsStringValue[0]);

            double difference = 0;

            bool isBeyondBoundary = false;
            if (awardedPoints > subquestionMaxPoints || awardedPoints < subquestionMaxPoints * (-1))
            {
                isBeyondBoundary = true;
            }

            string outcome = null;
            if (!isBeyondBoundary)
            {
                outcome = driver.FindElement(By.CssSelector("tr:nth-child(1) > .correct")).Text;
            }

            if (!isBeyondBoundary && questionPointsDetermined)
            {
                difference = oldInputPointsValue - awardedPoints;
                Assert.AreEqual(newInputPointsValue, awardedPoints);

                if (difference > 0)//počet bodů snížen
                {
                    Assert.AreEqual(newQuestionPointsValue, oldQuestionPointsValue - difference);
                    Assert.AreEqual(newSubquestionPointsValue, oldSubquestionPointsValue - difference);
                    Assert.AreEqual(newAnswerPointsValue, oldAnswerPointsValue - difference);
                }
                else if (difference < 0)//počet bodů zvýšen
                {
                    Assert.AreEqual(newQuestionPointsValue, oldQuestionPointsValue + Math.Abs(difference));
                    Assert.AreEqual(newSubquestionPointsValue, oldSubquestionPointsValue + Math.Abs(difference));
                    Assert.AreEqual(newAnswerPointsValue, oldAnswerPointsValue + Math.Abs(difference));
                }
                else//počet bodů stejný
                {
                    Assert.AreEqual(newQuestionPointsValue, oldQuestionPointsValue);
                    Assert.AreEqual(newSubquestionPointsValue, oldSubquestionPointsValue);
                    Assert.AreEqual(newAnswerPointsValue, oldAnswerPointsValue);
                }
            }
            else
            {
                Assert.AreEqual(newQuestionPointsValue, oldQuestionPointsValue);
                Assert.AreEqual(newSubquestionPointsValue, oldSubquestionPointsValue);
                Assert.AreEqual(newAnswerPointsValue, oldAnswerPointsValue);
            }

            if(outcome != null)
            {
                Assert.AreEqual(outcome, expectedOutcome);
            }

            driver.FindElement(By.Id("backBtn")).Click();

            var newTestPoints = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(5) > td")).Text;
            string[] newTestPointsStringValue = newTestPoints.Split("/");
            int newTestPointsValue = 0;
            if(questionPointsDetermined)
            {
                newTestPointsValue = int.Parse(newTestPointsStringValue[0]);
            }

            selectedQuestionTestPointsLabel = "tr:nth-child(" + (selectedItemIndex + 2).ToString() + ") > td:nth-child(5)";
            var newQuestionTestPoints = driver.FindElement(By.CssSelector(selectedQuestionTestPointsLabel)).Text;
            string[] newQuestionTestPointsStringValue = newQuestionTestPoints.Split("/");
            int newQuestionTestPointsValue = 0;
            if (questionPointsDetermined)
            {
                newQuestionTestPointsValue = int.Parse(newQuestionTestPointsStringValue[0]);
            }

            if (!isBeyondBoundary && questionPointsDetermined)
            {
                if (difference > 0)//počet bodů snížen
                {
                    Assert.AreEqual(newTestPointsValue, oldTestPointsValue - difference);
                    Assert.AreEqual(newQuestionTestPointsValue, oldQuestionTestPointsValue - difference);
                }
                else if (difference < 0)//počet bodů zvýšen
                {
                    Assert.AreEqual(newTestPointsValue, oldTestPointsValue + Math.Abs(difference));
                    Assert.AreEqual(newQuestionTestPointsValue, oldQuestionTestPointsValue + Math.Abs(difference));
                }
            }
            else
            {
                Assert.AreEqual(newTestPointsValue, oldTestPointsValue);
                Assert.AreEqual(newQuestionTestPointsValue, oldQuestionTestPointsValue);
            }

            if(questionPointsDetermined)
            {
                ResultPointsTestRestore(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, deliveryExecutionIdentifier, studentIdentifier, selectedSubitem, oldInputPointsValue.ToString(), subquestionMaxPoints, int.Parse(amountOfSubitems), selectedSubitemIndex, 1);
            }
        }

        public void ResultPointsTestRestore(string testNameIdentifier, string testNumberIdentifier, string itemNumberIdentifier, string itemNameIdentifier, string deliveryExecutionIdentifier, string studentIdentifier, string selectedSubitem, string studentsPoints, int subquestionMaxPoints, int amountOfSubitems, int subitemIndex, int questionPointsDetermined)
        {
            HomeController homeController = new HomeController();
            homeController.ManageSolvedItem(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, deliveryExecutionIdentifier, studentIdentifier, selectedSubitem, studentsPoints, subquestionMaxPoints, amountOfSubitems, subitemIndex, questionPointsDetermined);
        }

        private static readonly object[] _questionAttributesTestSource =
        {
            new object[] {"dbtest"},
            new object[] {"postest"},
            new object[] {"prtest"},
            new object[] {"switest"},
            new object[] {"tstest"},
            new object[] {"unexistenttest"}
        };

        [Test]//Mají všechny otázky správně nastavené atributy?
        [TestCaseSource(nameof(_questionAttributesTestSource))]
        public void QuestionAttributesTest(string testNameIdentifier)
        {
            Settings.CustomRole = 1;
            driver.Navigate().GoToUrl("https://localhost:7057/Home/TeacherMenu");
            driver.FindElement(By.Id("testTemplateListBtn")).Click();

            bool testExists = false;
            int testRow = 2;

            while (true)
            {
                try
                {
                    string cellContent = driver.FindElement(By.CssSelector("tr:nth-child(" + testRow.ToString() + ") > td:nth-child(1)")).Text;
                    if (cellContent == testNameIdentifier)
                    {
                        testExists = true;
                        testRow -= 2;
                        break;
                    }
                    testRow++;
                }
                catch
                {
                    break;
                }
            }

            //Existuje test se zadaným jménem?
            Assert.IsTrue(testExists);

            bool exceptionThrown = false;
            int questionIndex = 0;
            int amountOfQuestions = 0;
            try
            {
                if (testExists)
                {
                    string selectedTestButton = "testTemplateBtn_" + testRow.ToString();
                    driver.FindElement(By.Id(selectedTestButton)).Click();
                    amountOfQuestions = int.Parse(driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(4) > td")).Text);

                    while (true)
                    {
                        try
                        {
                            string selectedItemButton = "itemTemplateBtn_" + questionIndex.ToString();
                            driver.FindElement(By.Id(selectedItemButton)).Click();
                            string amountOfSubitems = driver.FindElement(By.CssSelector("tr:nth-child(5) > td:nth-child(2)")).Text;
                            if (int.Parse(amountOfSubitems) > 1)
                            {
                                int subquestionIndex = 1;
                                while (true)
                                {
                                    try
                                    {
                                        driver.FindElement(By.Id("selectedSubitem")).Click();
                                        {
                                            var dropdown = driver.FindElement(By.Id("selectedSubitem"));
                                            dropdown.FindElement(By.Id("subquestion-item-" + subquestionIndex.ToString())).Click();
                                        }
                                        driver.FindElement(By.Id("setSubitemBtn")).Click();

                                        //Je typ otázky podporovaný aplikací?
                                        string questionType = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(1) > td")).Text;
                                        Assert.That(questionType, Is.Not.EqualTo("Neznámý nebo nepodporovaný typ otázky!"));

                                        bool includesImage = true;
                                        try
                                        {
                                            _ = driver.FindElement(By.CssSelector(".image"));
                                        }
                                        catch
                                        {
                                            includesImage = false;
                                        }

                                        int elementIndex = 5;
                                        if (includesImage)
                                        {
                                            elementIndex = 6;
                                        }
                                        string questionTextCssSelector = ".article-table:nth-child(1) tr:nth-child(" + elementIndex.ToString() + ") > td:nth-child(1)";

                                        string questionText2 = driver.FindElement(By.CssSelector(questionTextCssSelector)).Text;

                                        //Má otázka nastavený (číselný) počet bodů?
                                        string questionPoints = driver.FindElement(By.CssSelector("tr:nth-child(6) > td:nth-child(2)")).Text;
                                        Assert.That(questionPoints, Is.Not.EquivalentTo("N/A"));

                                        //Vypisuje text otázky chybovou hlášku (popř. vůbec neexistuje)?
                                        string questionText = driver.FindElement(By.CssSelector(questionTextCssSelector)).Text;
                                        Assert.That(questionText, Is.Not.EquivalentTo("Chyba: otázka obsahuje více než jeden obrázek."));
                                        Assert.That(questionText, Is.Not.EquivalentTo("Chyba: otázka nemá pravděpodobně zadaný žádný text."));
                                        Assert.That(questionText, Is.Not.Null);

                                        if (questionType != "Volná odpověď, správná odpověď není automaticky určena" && questionType != "Volná odpověď, správná odpověď je automaticky určena")
                                        {
                                            //Má otázka alespoň jednu možnou odpověď? (pokud se nejedná o otázku s volnou odpovědí)
                                            bool possibleAnswerExists = true;
                                            try
                                            {
                                                _ = driver.FindElement(By.ClassName("possible-answer-item"));
                                            }
                                            catch
                                            {
                                                possibleAnswerExists = false;
                                            }
                                            Assert.True(possibleAnswerExists);

                                            //Má otázka alespoň jednu správnou odpověď? (pokud se nejedná o otázku s volnou odpovědí)
                                            bool correctAnswerExists = true;
                                            try
                                            {
                                                _ = driver.FindElement(By.ClassName("correct-answer-item"));
                                            }
                                            catch
                                            {
                                                correctAnswerExists = false;
                                            }
                                            Assert.True(correctAnswerExists);
                                        }
                                        subquestionIndex++;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                //Je typ otázky podporovaný aplikací?
                                string questionType = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(1) > td")).Text;
                                Assert.That(questionType, Is.Not.EqualTo("Neznámý nebo nepodporovaný typ otázky!"));

                                //Má otázka nastavený (číselný) počet bodů?
                                string questionPoints = driver.FindElement(By.CssSelector("tr:nth-child(6) > td:nth-child(2)")).Text;
                                Assert.That(questionPoints, Is.Not.EquivalentTo("N/A"));

                                bool includesImage = true;
                                try
                                {
                                    _ = driver.FindElement(By.CssSelector(".image"));
                                }
                                catch
                                {
                                    includesImage = false;
                                }

                                int elementIndex = 5;
                                if (includesImage)
                                {
                                    elementIndex = 6;
                                }
                                string questionTextCssSelector = ".article-table:nth-child(1) tr:nth-child(" + elementIndex.ToString() + ") > td:nth-child(1)";

                                //Vypisuje text otázky chybovou hlášku (popř. vůbec neexistuje)?
                                string questionText = driver.FindElement(By.CssSelector(questionTextCssSelector)).Text;
                                Assert.That(questionText, Is.Not.EquivalentTo("Chyba: otázka obsahuje více než jeden obrázek."));
                                Assert.That(questionText, Is.Not.EquivalentTo("Chyba: otázka nemá pravděpodobně zadaný žádný text."));
                                Assert.That(questionText, Is.Not.Null);

                                if (questionType != "Volná odpověď, správná odpověď není automaticky určena" && questionType != "Volná odpověď, správná odpověď je automaticky určena")
                                {
                                    //Má otázka alespoň jednu možnou odpověď? (pokud se nejedná o otázku s volnou odpovědí)
                                    bool possibleAnswerExists = true;
                                    try
                                    {
                                        _ = driver.FindElement(By.ClassName("possible-answer-item"));
                                    }
                                    catch
                                    {
                                        possibleAnswerExists = false;
                                    }
                                    Assert.True(possibleAnswerExists);

                                    //Má otázka alespoň jednu správnou odpověď? (pokud se nejedná o otázku s volnou odpovědí)
                                    bool correctAnswerExists = true;
                                    try
                                    {
                                        _ = driver.FindElement(By.ClassName("correct-answer-item"));
                                    }
                                    catch
                                    {
                                        correctAnswerExists = false;
                                    }
                                    Assert.True(correctAnswerExists);
                                }
                            }

                            //Má otázka přidělený nadpis?
                            string questionTitle = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(3) > td")).Text;
                            Assert.That(questionTitle, Is.Not.Null);

                            //Má otázka přidělené označení?
                            string questionLabel = driver.FindElement(By.CssSelector(".article-table:nth-child(1) tr:nth-child(4) > td")).Text;
                            Assert.That(questionLabel, Is.Not.Null);

                            driver.FindElement(By.Id("backBtn")).Click();
                            questionIndex++;
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                    }
                }
            }

            //V případě, že nastane neočekávaná chyba, test (falešně) projde - vypíšeme chybovou hlášku
            catch (Exception ex)
            {
                exceptionThrown = true;
                Console.WriteLine(ex.Message);
                Assert.IsFalse(exceptionThrown);
            }

            //Porovnáme očekávaný počet otázek s počtem skutečně zkontrolovaných otázek u každého testu
            Assert.That(amountOfQuestions, Is.EqualTo(questionIndex));
        }

        private static readonly object[] _templatePointsTestSource =
        {
            new object[] { 0, 3, 2, true, null, "Počet bodů u podotázky byl úspešně změněn."},
            new object[] { -1, 3, 2, true, null, null},
            new object[] { 7, 3, 2, false, -7, "Počet bodů u podotázky byl úspešně změněn."},
            new object[] { 7, 3, 2, false, -7.01, null},
            new object[] { 7, 3, 2, false, 0, "Počet bodů u podotázky byl úspešně změněn."},
            new object[] { 7, 3, 2, false, 0.01, null}
        };

        [Test]//Funguje změna počtu bodů u šablony správně?
        [TestCaseSource(nameof(_templatePointsTestSource))]
        public void TemplatePointsTest(int allocatedPoints, int selectedTestIndex, int selectedItemIndex, bool testedRecommendedWrongChoicePoints, double testedSelectedWrongChoicePoints, string expectedOutcome)
        {
            Settings.CustomRole = 1;

            driver.Navigate().GoToUrl("https://localhost:7057/Home/TeacherMenu");
            driver.FindElement(By.Id("testTemplateListBtn")).Click();
            driver.FindElement(By.Id("testTemplateBtn_" + selectedTestIndex.ToString())).Click();

            //Sběr dat o pokusu (test) pro pozdější obnovu dat
            string testNameIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(1) > td")).Text;
            string testNumberIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(2) > td")).Text;

            var oldTestPoints = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(5) > td")).Text;

            string selectedQuestionTestPointsLabel = "tr:nth-child(" + (selectedItemIndex + 2).ToString() + ") > td:nth-child(5)";
            var oldQuestionTestPoints = driver.FindElement(By.CssSelector(selectedQuestionTestPointsLabel)).Text;

            driver.FindElement(By.Id("itemTemplateBtn_" + selectedItemIndex.ToString())).Click();

            //Sběr dat o pokusu (otázka) pro pozdější obnovu dat
            string itemNumberIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(2) > td")).Text;
            string itemNameIdentifier = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(1) > td")).Text;
            string selectedSubitem = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(2) > td")).Text;
            string wrongChoicePoints = null;
            if(driver.FindElement(By.Id("wrongChoicePoints_recommended")).Selected)
            {
                wrongChoicePoints = "wrongChoicePoints_recommended";
            }
            string recommendedWrongChoicePoints = driver.FindElement(By.Id("wrongChoicePoints_recommended_points")).GetAttribute("value");
            string selectedWrongChoicePoints = driver.FindElement(By.Id("wrongChoicePoints_selected_points")).GetAttribute("value");
            string correctChoicePointsToParse = driver.FindElement(By.Id("subquestion-correct-choice-points")).GetAttribute("value");
            double correctChoicePoints = double.Parse(correctChoicePointsToParse.Replace(".", ","));
            List<string> correctChoiceArray = new List<string>();
            int correctChoiceArrayCount = 0;
            foreach (var item in driver.FindElements(By.ClassName("correct-answer-item")))
            {
                correctChoiceArrayCount++;
            }
            int correctChoiceArrayCountAlternative = correctChoiceArrayCount;
            int questionType = GetQuestionType(driver.FindElement(By.CssSelector(".article-table:nth-child(1) tr:nth-child(5) > td:nth-child(1)")).Text);

            var oldInputPoints = driver.FindElement(By.Id("subquestion-points"));
            int oldInputPointsValue = int.Parse(oldInputPoints.GetAttribute("value"));

            var oldQuestionPoints = driver.FindElement(By.CssSelector(".article-table:nth-child(1) tr:nth-child(6) > td")).Text;

            var oldSubquestionPoints = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(3) > td")).Text;

            oldInputPoints.Clear();
            driver.FindElement(By.Id("subquestion-points")).SendKeys((allocatedPoints).ToString());

            if(testedRecommendedWrongChoicePoints)
            {
                driver.FindElement(By.Id("wrongChoicePoints_recommended")).Click();
            }
            else
            {
                driver.FindElement(By.Id("wrongChoicePoints_selected")).Click();
                driver.FindElement(By.Id("wrongChoicePoints_selected_points")).Clear();
                driver.FindElement(By.Id("wrongChoicePoints_selected_points")).SendKeys((testedSelectedWrongChoicePoints).ToString().Replace(",", "."));
            }
            driver.FindElement(By.Id("setSubquestionPointsBtn")).Click();

            var newInputPoints = driver.FindElement(By.Id("subquestion-points"));
            int newInputPointsValue = int.Parse(newInputPoints.GetAttribute("value"));

            var newQuestionPoints = driver.FindElement(By.CssSelector(".article-table:nth-child(1) tr:nth-child(6) > td")).Text;

            var newSubquestionPoints = driver.FindElement(By.CssSelector(".article:nth-child(3) tr:nth-child(3) > td")).Text;

            int difference = 0;

            bool isBeyondBoundary = false;
            if(allocatedPoints < 0 || allocatedPoints < (testedSelectedWrongChoicePoints * (-1)) || testedSelectedWrongChoicePoints > 0)
            {
                isBeyondBoundary = true;
            }

            string outcome = null;
            if (!isBeyondBoundary)
            {
                outcome = driver.FindElement(By.CssSelector(".correct")).Text;
            }

            if (!isBeyondBoundary)
            {
                difference = oldInputPointsValue - allocatedPoints;
                Assert.AreEqual(newInputPointsValue, allocatedPoints);

                if (difference > 0)//počet bodů snížen
                {
                    Assert.AreEqual(newQuestionPoints, (int.Parse(oldQuestionPoints) - difference).ToString());
                    Assert.AreEqual(newSubquestionPoints, (int.Parse(oldSubquestionPoints) - difference).ToString());
                }
                else if (difference < 0)//počet bodů zvýšen
                {
                    Assert.AreEqual(newQuestionPoints, (oldQuestionPoints + Math.Abs(difference)).ToString());
                    Assert.AreEqual(newSubquestionPoints, (oldSubquestionPoints + Math.Abs(difference)).ToString());
                }
                else//počet bodů stejný
                {
                    Assert.AreEqual(newQuestionPoints, oldQuestionPoints);
                    Assert.AreEqual(newSubquestionPoints, oldSubquestionPoints);
                }
            }
            else
            {
                if(oldInputPointsValue != allocatedPoints)
                {
                    Assert.AreNotEqual(newInputPointsValue, oldInputPointsValue);
                }
                Assert.AreEqual(newQuestionPoints, oldQuestionPoints);
                Assert.AreEqual(newSubquestionPoints, oldSubquestionPoints);
            }

            if(outcome != null)
            {
                Assert.AreEqual(outcome, expectedOutcome);
            }

            driver.FindElement(By.Id("backBtn")).Click();
            var newTestPoints = driver.FindElement(By.CssSelector(".article:nth-child(1) tr:nth-child(5) > td")).Text;

            selectedQuestionTestPointsLabel = "tr:nth-child(" + (selectedItemIndex + 2).ToString() + ") > td:nth-child(5)";
            var newQuestionTestPoints = driver.FindElement(By.CssSelector(selectedQuestionTestPointsLabel)).Text;

            if (!isBeyondBoundary)
            {
                if (difference > 0)//počet bodů snížen
                {
                    Assert.AreEqual(newTestPoints, (int.Parse(oldTestPoints) - difference).ToString());
                    Assert.AreEqual(newQuestionTestPoints, (int.Parse(oldQuestionTestPoints) - difference).ToString());
                }
                else if (difference < 0)//počet bodů zvýšen
                {
                    Assert.AreEqual(newTestPoints, (oldTestPoints + Math.Abs(difference)).ToString());
                    Assert.AreEqual(newQuestionTestPoints, (oldQuestionTestPoints + Math.Abs(difference)).ToString());
                }
            }
            else
            {
                Assert.AreEqual(newTestPoints, oldTestPoints);
                Assert.AreEqual(newQuestionTestPoints, oldQuestionTestPoints);
            }

            TemplatePointsTestRestore(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, selectedSubitem, oldInputPointsValue.ToString(), 
                wrongChoicePoints, recommendedWrongChoicePoints, selectedWrongChoicePoints, correctChoicePoints, correctChoiceArray, correctChoiceArrayCount, correctChoiceArrayCountAlternative, questionType);
        }

        public void TemplatePointsTestRestore(string testNameIdentifier, string testNumberIdentifier, string itemNumberIdentifier, string itemNameIdentifier, string selectedSubitem, string subquestionPoints,
            string wrongChoicePoints, string recommendedWrongChoicePoints, string selectedWrongChoicePoints, double correctChoicePoints, List<string> correctChoiceArray, int correctChoiceArrayCount, int correctChoiceArrayCountAlternative, int questionType)
        {
            HomeController homeController = new HomeController();
            homeController.ItemTemplate(testNameIdentifier, testNumberIdentifier, itemNumberIdentifier, itemNameIdentifier, selectedSubitem, subquestionPoints,
                wrongChoicePoints, recommendedWrongChoicePoints, selectedWrongChoicePoints, correctChoicePoints, correctChoiceArray, correctChoiceArrayCount, correctChoiceArrayCountAlternative, questionType);
        }

        public int GetQuestionType(string questionTypeText)
        {
            switch (questionTypeText)
            {
                case "Neznámý nebo nepodporovaný typ otázky!":
                    return 0;
                case "Seřazení pojmů":
                    return 1;
                case "Výběr z více možností; více možných správných odpovědí":
                    return 2;
                case "Spojování pojmů":
                    return 3;
                case "Více otázek k jednomu pojmu; více možných správných odpovědí":
                    return 4;
                case "Volná odpověď, správná odpověď není automaticky určena":
                    return 5;
                case "Výběr z více možností; jedna správná odpověd":
                    return 6;
                case "Výběr z více možností (doplnění textu); jedna správná odpověď":
                    return 7;
                case "Volná odpověď, správná odpověď je automaticky určena":
                    return 8;
                case "Dosazování pojmů do mezer":
                    return 9;
                case "Posuvník; jedna správná odpověď (číslo)":
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
