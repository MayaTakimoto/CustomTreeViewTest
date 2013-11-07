using Livet;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CustomTreeViewTest
{
    [ProtoContract]
    public class CustomTreeNodeList : ViewModel
    {
        //private CustomTreeNode selectedNode;

        [ProtoMember(1)]
        private ObservableCollection<CustomTreeNode> nodes;

        /// <summary>
        /// 子ノードのリストのプロパティ
        /// </summary>
        public ObservableCollection<CustomTreeNode> Nodes 
        {
            get 
            {
                return this.nodes;
            }
            set
            { 
                this.nodes = value;
                RaisePropertyChanged("Nodes");
            }
        }

        private List<CustomTreeNode> findNodes;
        private int index;

        //public CustomTreeNode SelectedNode
        //{
        //    get
        //    {
        //        return this.selectedNode;
        //    }
        //    set
        //    {
        //        this.selectedNode = value;
        //        RaisePropertyChanged("SelectedNode");
        //    }
        //}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustomTreeNodeList()
        {
            Nodes = new ObservableCollection<CustomTreeNode>();
            //SelectedNode = new CustomTreeNode();
            index = 0;
        }

        public void Add()
        {
            CustomTreeNode cnAdd = new CustomTreeNode();

            cnAdd.Name = "TEST" + this.Nodes.Count;
            cnAdd.Tag = "これはテストです。その" + this.Nodes.Count;

            AddNode(Nodes, cnAdd);
        }

        private int AddNode(ObservableCollection<CustomTreeNode> oc, CustomTreeNode cnAdd)
        {
            int iRet = -1;

            if (Nodes.Count == 0)
            {
                Nodes.Add(cnAdd);
                return 0;
            }

            foreach (CustomTreeNode cn in oc)
            {
                if (cn.IsSelected)
                {
                    if (cn.MaxNodesCount == cn.Nodes.Count)
                    {
                        return 0;
                    }

                    cn.Nodes.Add(cnAdd);
                    return 0;
                }
                else if (cn.Nodes != null || cn.Nodes.Count > 0)
                {
                    iRet = AddNode(cn.Nodes, cnAdd);
                    if (iRet == 0)
                    {
                        return 0;
                    }
                }
            }

            return -1;
        }

        public void Serialize()
        {
            using (MemoryStream ms = new MemoryStream(1024))
            {
                Serializer.Serialize(ms, this);

                byte[] bs = ms.ToArray();

                File.WriteAllBytes("test.txt", bs);
            }

            MessageBox.Show("Done");
        }

        public void Clear()
        {
            this.Nodes.Clear();
        }

        public void Search()
        {
            if (findNodes == null || findNodes.Count == 0)
            {
                findNodes = new List<CustomTreeNode>();

                SearchNodes(this.Nodes);
            }

            if (index == findNodes.Count)
            {
                index = 0;
            }

            findNodes[index].IsSelected = true;
            findNodes[index].IsExpanded = true;
            findNodes[index].IsFocusable = true;

            index++;
        }

        private void SearchNodes(ObservableCollection<CustomTreeNode> Nodes)
        {
            findNodes.AddRange(Nodes.Where((node) => { return node.Name.Contains("TEST"); }).ToList());

            foreach (var child in Nodes)
            {
                SearchNodes(child.Nodes);
            }
        }
    }
}
