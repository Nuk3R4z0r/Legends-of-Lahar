using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Legends_Of_Lahar
{
    public class Area
    {
        public const int AREA_CRATER = 0; //Deserts area 0
        public const int AREA_DRYSTEPPES = 1; //Deserts area 1

        public string _name;
        private int _areaId;
        private List<Enemy> _areaEntities; //Entities i området
        public Bitmap _areaPic; //Environment billede
        
        public Area(int areaId)
        {
            _areaId = areaId;

            switch(_areaId)
            {
                case AREA_CRATER:
                    _name = "Crater";
                    _areaPic = Properties.Resources.CraterBackground;
                    break;
                case AREA_DRYSTEPPES:
                    break;
            }

            _areaEntities = MonsterData.GetMonsterList(_areaId);
        }

        public Enemy GetFirstEntity()
        {
            Enemy rEntity = _areaEntities[0];
            //_areaEntities.RemoveAt(0);
            return rEntity;
        }

        public List<Enemy> ListEntities()
        {
            return _areaEntities;
        }

        public int GetAreaId()
        {
            return _areaId;
        }
    }
}
