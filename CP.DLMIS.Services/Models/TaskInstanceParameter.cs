using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CP.DLMIS.Services.Models
{

    /// <summary>
    /// 产生任务信息相关参数定义
    /// </summary>
    public class TaskInstanceParameter
    {
        public TaskInstanceParameter()
        {
            this._projectstarttime = DateTime.Now; 
        }
        
        #region Model
        private string _tasktitle ="" ;
        private int _projectid = 0;
        private string _projectcode ="" ;
        private string _projectname = "";
        private int _projectphaseid = 0;
        private string _projectphasecode = "";
        private string _projectphasename = "";
        private string _projectzyid = "";
        private string _projectzyname = "";
        private string _projectmanauserid = "";
        private string _projectmanausername = "";
        private string _projectdirectorid = "";
        private string _projectdirectorname = "";
        private string _projectdepid = "";
        private string _projectdepname = "";
        /// <summary>
        /// 设计号，暂时在流程里没用，用来传参数用
        /// </summary>
        private string _projectNumber = "";//
        private DateTime _projectstarttime;
        private string _dxName = "";
        private string _paraex1 = "";
        private string _paraex2 = "";
        private string _paraex3 = "";
        private string _paraex4 = "";
        private string _paraex5 = "";
        private string _paraex6 = "";
        private string _paraex7 = "";
        private string _paraex8 = "";
        private string _paraex9 = "";
        private string _paraex10 = "";
        private string _formPk1 = "";
        /// <summary>
        /// 单项名称
        /// </summary>
        public string DXName
        {
            get
            {
                return this._dxName;
            }
            set
            {
                this._dxName = value;
            }
        }
        public string FormPk1
        {
            get
            {
                return this._formPk1;
            }
            set
            {
                this._formPk1 = value;
            }
        }
        private string _formPk2;
        public string FormPk2
        {
            get
            {
                return this._formPk2;
            }
            set
            {
                this._formPk2 = value;
            }
        }
        private string _fromUrl = "";
        public string FormUrl
        {
            get
            {
                return this._fromUrl;
            }
            set
            {
                this._fromUrl = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TaskTitle
        {
            set { _tasktitle = value; }
            get { return _tasktitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectCode
        {
            set { _projectcode = value; }
            get { return _projectcode; }
        }
        private string _projectcode_mt = "";
        /// <summary>
        /// 煤炭对取项目号的特殊处理
        /// </summary>
        public string ProjectCode_MT
        {
            set { _projectcode_mt = value; }
            get { return _projectcode_mt; }
        }
        /// <summary>
        /// 存储客户真正的项目号
        /// </summary>
        public string ProjectCodeCustomer { get; set; }
        /// <summary>
        /// 中山项目对项目号的特殊处理
        /// </summary>
        public string ProjectCode_ZS
        {
            get
            {
                //P-08-0411_802
                string s = this.ProjectCode;
                if (string.IsNullOrEmpty(s) == false)
                {
                    if (s.IndexOf("_") != -1)
                    {
                        s = s.Substring(0, s.LastIndexOf("_"));
                    }
                }
                return s;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 图纸管理系统，合景项目，把客户的产品当成项目，所以这里存储的是客户真正的项目名称
        /// </summary>
        public string ProjectNameMY
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectPhaseId
        {
            set { _projectphaseid = value; }
            get { return _projectphaseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectPhaseCode
        {
            set { _projectphasecode = value; }
            get { return _projectphasecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectPhaseName
        {
            set { _projectphasename = value; }
            get { return _projectphasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectZYId
        {
            set { _projectzyid = value; }
            get { return _projectzyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectZYName
        {
            set { _projectzyname = value; }
            get { return _projectzyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectManaUserId
        {
            set { _projectmanauserid = value; }
            get { return _projectmanauserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectManaUserName
        {
            set { _projectmanausername = value; }
            get { return _projectmanausername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectDirectorId
        {
            set { _projectdirectorid = value; }
            get { return _projectdirectorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectDirectorName
        {
            set { _projectdirectorname = value; }
            get { return _projectdirectorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectDepId
        {
            set { _projectdepid = value; }
            get { return _projectdepid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectDepName
        {
            set { _projectdepname = value; }
            get { return _projectdepname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ProjectStartTime
        {
            set { _projectstarttime = value; }
            get { return _projectstarttime; }
        }
        /// <summary>
        /// 设计号，暂时在流程里没用，用来传参数用
        /// </summary>
        public string ProjectNumber
        {
            get
            {
                return this._projectNumber;
            }
            set
            {
                this._projectNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx1
        {
            set { _paraex1 = value; }
            get { return _paraex1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx2
        {
            set { _paraex2 = value; }
            get { return _paraex2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx3
        {
            set { _paraex3 = value; }
            get { return _paraex3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx4
        {
            set { _paraex4 = value; }
            get { return _paraex4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx5
        {
            set { _paraex5 = value; }
            get { return _paraex5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx6
        {
            set { _paraex6 = value; }
            get { return _paraex6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx7
        {
            set { _paraex7 = value; }
            get { return _paraex7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx8
        {
            set { _paraex8 = value; }
            get { return _paraex8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx9
        {
            set { _paraex9 = value; }
            get { return _paraex9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParaEx10
        {
            set { _paraex10 = value; }
            get { return _paraex10; }
        }
        /// <summary>
        /// 图纸管理系统分期名称
        /// </summary>
        public string YTDesign_FQName { get; set; }
        /// <summary>
        /// 图纸管理系统产品名称
        /// </summary>
        public string YTDesign_ProductName { get; set; }
        #endregion Model

        

    }
}
