using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicRandomData
{
    /// <summary>
    /// 用户角色
    /// </summary>
    enum UserType
    {
        /// <summary>
        /// 基础数据管理员
        /// </summary>
        BaseDataManager,
        /// <summary>
        /// 系统规则制定
        /// </summary>
        GameRuleManager,
        /// <summary>
        /// 抽查结果维护
        /// </summary>
        ResultManager,
        /// <summary>
        /// 系统监督
        /// </summary>
        SystemSupervise
    }
}
