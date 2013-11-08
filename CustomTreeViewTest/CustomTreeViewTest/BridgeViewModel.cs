using Livet;
using ProtoBuf;
using System;
using System.IO;

namespace CustomTreeViewTest
{
    class BridgeViewModel : ViewModel
    {
        private CustomTreeNodeList tree;

        public CustomTreeNodeList Tree
        {
            get 
            { 
                return this.tree;
            }
            set
            {
                this.tree = value;
                RaisePropertyChanged("Tree");
            }
        }

        public BridgeViewModel()
        {
            if (File.Exists("test.txt"))
            {
                byte[] bs = File.ReadAllBytes("test.txt");

                using (MemoryStream ms = new MemoryStream(bs))
                {
                    Tree = Serializer.Deserialize<CustomTreeNodeList>(ms);
                }
            }
            else
            {
                Tree = new CustomTreeNodeList();
            }

            //GC.Collect();
        }
    }
}
