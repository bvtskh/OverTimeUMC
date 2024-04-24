
using PI_Lib.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OverTime.Business
{
    public class GAMankuchi
    {
        public List<Tbl_Mankichi_Entity> _listCurrentStaff = null;
        private static GAMankuchi _instance;

        protected GAMankuchi()
        {
            _listCurrentStaff = PI_Lib.MankichiHelper.GetAllStaffWorking();
        }

        public static GAMankuchi Instance()
        {
            if (_instance == null)
            {
                _instance = new GAMankuchi();
            }

            return _instance;
        }
    }

    public class GAMankuchiAll
    {
        public List<Tbl_Mankichi_Entity> _listAllStaff = null;

        private static GAMankuchiAll _instance;

        protected GAMankuchiAll()
        {
            _listAllStaff = PI_Lib.MankichiHelper.GetAllStaff();
        }

        public static GAMankuchiAll Instance()
        {
            if (_instance == null)
            {
                _instance = new GAMankuchiAll();
            }

            return _instance;
        }
    }


}
