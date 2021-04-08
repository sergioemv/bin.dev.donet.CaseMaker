using System;
using System.Collections.Generic;
using CaseMaker.Edits;
using CaseMaker.Entities.Testcases;
using CaseMaker.Localization;
using CaseMaker.Policies;

namespace CaseMaker.Generation.TestCases
{

    internal class OneWiseTestCasesGenerator : IGenerator
    {
        private TestCasesStructure structure;
        private int maxPositiveTC;

        public OneWiseTestCasesGenerator(TestCasesStructure structure, int maxPositiveTC)
        {
            this.structure = structure;
            this.maxPositiveTC = maxPositiveTC;
        }


        public IUndoableEdit Generate()
        {
		CompoundEdit ce = new CompoundEdit();
		List<TestCase> newTestCases = new List<TestCase>();
		
		//for each element in the test object
		foreach (Element element in structure.Elements)
		{
			//for each positive equivalence class in the element
			foreach (EquivalenceClass eClass in element.GetEquivalenceClassesbyState(State.POSITIVE))
			{
				//check if the equivalence class is used in any of the test cases of the structure (including negative and faulty test cases)
				bool isUsed = false;
				foreach (TestCase testCase in structure.TestCases)
					if (testCase.GetAllEquivalenceClasses().Contains(eClass))
						isUsed = true;
				//if is not used find a positive test case that does not use antother equivalence class of the same element
				if (!isUsed)
				{
					bool assigned = false;
					foreach (TestCase testCase in structure.GetTestCases(State.POSITIVE))
						//if theres an positive test case asign the equivalence Class to the test case
						if (!testCase.GetAllElements().Contains(eClass.ParentElement)&&!assigned)
						{
							ce.AddEdit(PolicyFactory.instance.AddEquivalenceClassToTestCase(eClass, testCase));
		                    assigned = true;
						}
					//check also in the newly generated test cases
					foreach (TestCase testCase in newTestCases)
						if (!testCase.GetAllElements().Contains(eClass.ParentElement)&&!assigned){
							ce.AddEdit(PolicyFactory.instance.AddEquivalenceClassToTestCase(eClass, testCase));
				              assigned = true;
						}
					//if theres not any positive test case create a new positive test case  with that assignment of equivalence class
					if (!assigned)
					{
						//create and initialize the new test case
						TestCase testCase = new TestCase();
					    ce.AddEdit(EditFactory.instance.CreateChangeStateEdit(testCase, State.POSITIVE));
					    testCase.CurrentState = State.POSITIVE;
				        ce.AddEdit(EditFactory.instance.CreateChangePropertyEdit(testCase,"Origin",TestCaseOrigin.GENERATED));
					    testCase.Origin = TestCaseOrigin.GENERATED;
				    	ce.AddEdit(PolicyFactory.instance.AddEquivalenceClassToTestCase(eClass, testCase));
	                   // ce.addEdit(TestCaseManager.INSTANCE.updateTestCaseDescription(testCase, structure));
						newTestCases.Add(testCase);
					}
				} // if is used
			}// for each equivalence class
		}//for each element
		//Verify the Size of the new test cases if is not bigger than the allowed
		if (newTestCases.Count>0)
		{
			if ((newTestCases.Count+structure.GetTestCases(State.POSITIVE).Count)>maxPositiveTC)
			{
			    throw new Exception("Max reached");

			}else
			{
			    foreach (TestCase tc in newTestCases)
			    {
                    ce.AddEdit(EditFactory.instance.CreateAddTestCaseEdit(structure, tc));
                    structure.AddTestCase(tc);
			    }
                

			}

		}

		
		return ce;
	}


    }
    }       
