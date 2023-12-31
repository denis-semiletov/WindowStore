namespace WindowStore.Shared.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItem> ConvertEnumToDropDownSource<T>(string initialText, string initialValue)
        {
            List<DropDownListItem> ret = [];
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList() ?? [];

            if (!string.IsNullOrEmpty(initialValue) || !string.IsNullOrEmpty(initialText))
            {
                DropDownListItem ddlInitialItem = new()
                {
                    Text = initialText,
                    Value = initialValue
                };
                ret.Add(ddlInitialItem);
            }

            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
            {
                DropDownListItem ddlItem = new()
                {
                    Text = Enum.GetNames(typeof(T))[i],
                    Value = values[i].ToString()
                };

                ret.Add(ddlItem);
            }

            return ret;
        }
    }
}
