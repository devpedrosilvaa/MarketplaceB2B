using System.ComponentModel;

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

        public static string StringValueOf(Enum value) {
            var fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[]) 
                fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
    }
}
