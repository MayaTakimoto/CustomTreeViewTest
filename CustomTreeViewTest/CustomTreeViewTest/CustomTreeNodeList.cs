using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTreeViewTest
{
    [ProtoContract]
    public class CustomTreeNodeList
    {
         /// <summary>
        /// 子ノードのリストのプロパティ
        /// </summary>
        [ProtoMember(1)]
        public ObservableCollection<CustomTreeNode> Nodes { get; private set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomTreeNodeList()
        {
            Nodes = new ObservableCollection<CustomTreeNode>();
        }

        public void Add()
        {
            //CustomTreeNode c = new CustomTreeNode();
            //c.Name = "origin";

            for (int cnt = 0; cnt < 100; cnt++)
            {
                CustomTreeNode cHome = new CustomTreeNode();

                cHome.Name = "home" + (cnt + 1);
                cHome.Tag = "おや" + (cnt + 1);
                
                for (int i = 0; i < 60; i++)
                {
                    CustomTreeNode ct = new CustomTreeNode();

                    ct.Name = "test" + (i + 1);
                    ct.Tag = "こども" + (i + 1);

                    for (int j = 0; j < 30; j++)
                    {
                        CustomTreeNode cct = new CustomTreeNode();

                        cct.Name = "child" + (j + 1);
                        cct.Tag = "まごおおおおおおおおおおおおおおおおおおおおおおおおおおおん" + (j + 1);

                        ct.ListTreeNodes.Add(cct);
                    }

                    cHome.ListTreeNodes.Add(ct);
                }

                Nodes.Add(cHome);
            }

            //Nodes.Add(c);
        }
    }
}
