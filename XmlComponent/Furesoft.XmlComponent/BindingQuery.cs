using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace XmlComponent
{
    public class BindingQuery
    {
        public string Property { get; set; }
        public bool Children { get; set; }

        public void Parse(string path)
        {
            if (path == null)
                throw new System.ArgumentNullException(nameof(path));

            Contract.Requires(path != null);

            var m = Regex.Match(path, @"{(?<prop>(\[children\]|(\w|\d)+))}", RegexOptions.IgnoreCase);

            if(m.Success)
            {
                if(m.Groups["prop"].Value.ToLower() == "[children]")
                {
                    Children = true;
                }
                else
                {
                    Property = m.Groups["prop"].Value;
                }
            }

        }

        public bool IsBindingQuery(string path) => Regex.IsMatch(path, @"{(?<prop>(\[children\]|(\w|\d)+))}", RegexOptions.IgnoreCase);
    }
}