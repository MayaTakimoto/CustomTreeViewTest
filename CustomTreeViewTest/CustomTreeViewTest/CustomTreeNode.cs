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
    public class CustomTreeNode
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string Tag { get; set; }

        /// <summary>
        /// 子ノードのリストのプロパティ
        /// </summary>
        [ProtoMember(3)]
        public ObservableCollection<CustomTreeNode> ListTreeNodes
        {
            get;
            set;
        }

        public CustomTreeNode()
        {
            ListTreeNodes = new ObservableCollection<CustomTreeNode>();
            Name = string.Empty;
            Tag = null;
        }
    }
}
