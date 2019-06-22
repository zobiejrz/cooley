using System;
namespace dnd_character_storage.Resources.Datatypes
{
    [Serializable]
    public class Item
    {
        public string Name          { get; set; }
        public string Description   { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Description}";
        }
    }

}