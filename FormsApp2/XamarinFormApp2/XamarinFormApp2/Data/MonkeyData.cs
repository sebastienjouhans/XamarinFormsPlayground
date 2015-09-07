namespace XamarinFormApp2.Data
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using XamarinFormApp2.Entities;

    public class MonkeyData
    {

        static MonkeyData()
        {
            if (All == null)
            {
                All = new ObservableCollection<Monkey>
                          {
                              new Monkey
                                  {
                                      Name = "Chimpanzee",
                                      Family = "Hominidae",
                                      Subfamily = "Homininae",
                                      Tribe = "Panini",
                                      Genus = "Pan",
                                      PhotoUrl =
                                          "http://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Schimpanse_Zoo_Leipzig.jpg/640px-Schimpanse_Zoo_Leipzig.jpg"
                                  },
                              new Monkey
                                  {
                                      Name = "Orangutan",
                                      Family = "Hominidae",
                                      Subfamily = "Ponginae",
                                      Genus = "Pongo",
                                      PhotoUrl =
                                          "http://upload.wikimedia.org/wikipedia/commons/b/be/Orang_Utan%2C_Semenggok_Forest_Reserve%2C_Sarawak%2C_Borneo%2C_Malaysia.JPG"
                                  },
                              new Monkey
                                  {
                                      Name = "Tamarin",
                                      Family = "Callitrichidae",
                                      Genus = "Saguinus",
                                      PhotoUrl =
                                          "http://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Tamarin_portrait_2_edit3.jpg/640px-Tamarin_portrait_2_edit3.jpg"
                                  }
                          };
            }
        }

        public static IList<Monkey> All { set; get; }
    }

}
