using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Models
{
    public abstract class StepParameter<TRowObject>
        where TRowObject : new()
    {
        [StepArgumentTransformation]
        protected virtual TRowObject CreateInstance(Table specflowTable)
        {
            return specflowTable.CreateInstance<TRowObject>();
        }

        [StepArgumentTransformation]
        protected virtual List<TRowObject> CreateSet(Table specflowTable)
        {
            return specflowTable.CreateSet<TRowObject>().ToList();
        }

        protected bool CheckEquality(TRowObject obj1, object obj2)
        {
            if (obj2 == null) return false;
            if (obj2.GetType() != obj1.GetType()) return false;

            var castedObject = (TRowObject)obj2;
            var obj1Prorepties = obj1.GetType().GetProperties();
            var obj2Prorepties = castedObject.GetType().GetProperties();

            return !obj1Prorepties.Where((t, i) => t.GetValue(obj1).ToString() != obj2Prorepties[i].GetValue(castedObject).ToString()).Any();
        }
    }
}