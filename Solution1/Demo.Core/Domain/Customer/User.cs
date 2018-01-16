using System;

namespace Demo.Core.Domain.Customer
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// 标识列
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// 岗位地址
        /// </summary>
        public string JobAddress { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? InductionDate { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime? ResignDate { get; set; }

        public UsedMode IsUsed { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatePerson { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyPerson { get; set; }
    }
}
