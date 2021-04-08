using CaseMaker.DAO;
using CaseMaker.Entities;

/// <summary>
/// Summary description for tempFillTestObject
/// </summary>
public class tempFillTestObject
{
    public static TestObject getTestObject()
    {
        TestObject defaultTo;
        TestObjectDAO dao1 = new TestObjectDAO();
        defaultTo = dao1.GetTestObjectByName("Testing TestCases");

        if (defaultTo == null)
        {
            defaultTo = new TestObject("Testing TestCases");
            dao1.SaveAll(defaultTo);
        }
        dao1.SyncObject(defaultTo.TestCasesStruct);
        return defaultTo;
    }
}