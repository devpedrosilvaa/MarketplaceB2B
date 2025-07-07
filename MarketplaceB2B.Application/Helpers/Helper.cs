using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Application.Helpers {
    public class Helper {

        #region Enums
        public enum DefaultMessage {
            [Description("Insert completed successfully!")]
            INSERT = 0,
            [Description("Update completed successfully!")]
            UPDATE = 0,
            [Description("Delete completed successfully!")]
            DELETE = 0,
            [Description("Existing record!")]
            EXISTING_RECORD = 0,
        }
        #endregion

    }
}
