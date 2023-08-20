using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise21_Tusindfryd
{
    public class ProductionTrayRepository
    {
        List<ProductionTray> productionTrays;

        public ProductionTrayRepository () {
            productionTrays = new List<ProductionTray>();
        }

        public void Add (ProductionTray productionTray) {
            productionTrays.Add(productionTray);
        }

        public ProductionTray Get (string name) {
            foreach (ProductionTray productionTray in productionTrays) {
                if (productionTray.Name.Equals(name))
                    return productionTray;
            }

            return null;
        }

        public void Remove (ProductionTray productionTray) {
            productionTrays.Remove(productionTray);
        }
    }
}
