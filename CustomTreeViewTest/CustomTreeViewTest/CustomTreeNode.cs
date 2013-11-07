using Livet;
using ProtoBuf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CustomTreeViewTest
{
    [ProtoContract]
    public class CustomTreeNode : ViewModel
    {
        private bool isSelected;
        private bool isExpanded;
        private bool isFocusable;

        [ProtoMember(1)]
        private string name;

        [ProtoMember(2)]
        private string tag;

        [ProtoMember(3)]
        public ObservableCollection<CustomTreeNode> Nodes { get; set; }

        [ProtoMember(4)]
        private int maxNodesCnt;

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    RaisePropertyChanged("IsExpanded");
                }
            }
        }

        public bool IsFocusable
        {
            get
            {
                return this.isFocusable;
            }
            set
            {
                if (this.isFocusable != value)
                {
                    this.isFocusable = value;
                    RaisePropertyChanged("IsFocusable");
                }
            }
        }

        public int MaxNodesCount
        {
            get 
            { 
                return this.maxNodesCnt;
            }
            set
            {
                this.maxNodesCnt = value;
                RaisePropertyChanged("MaxNodesCount");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
                RaisePropertyChanged("Tag");
            }
        }


        public CustomTreeNode()
        {
            Nodes = new ObservableCollection<CustomTreeNode>();
            Name = string.Empty;
            Tag = null;
            IsSelected = false;
            MaxNodesCount = 100;
        }
    }
}
