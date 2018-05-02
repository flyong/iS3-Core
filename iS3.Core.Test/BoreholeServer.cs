using iS3.Geology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core.Test
{
    public sealed class BoreholeServer
    {
        private readonly IBoreholeRepository _boreholeRepository;


        public BoreholeServer(IBoreholeRepository boreholeRepository)
        {
            _boreholeRepository = boreholeRepository;
        }

        public string CreateBorehole(Borehole obj)
        {

            return string.Format("新增ID为{0}的钻孔", _boreholeRepository.Create(obj).ToString());
        }

        public string DeteleBorehole(int key)
        {

            return string.Format("删除ID为{0}的钻孔{1}个", key.ToString(), _boreholeRepository.Delete(key).ToString());
        }
        public string ViewBorehole(int key)
        {
            return string.Format("查看:{0}", key.ToString(), _boreholeRepository.Retrieve(key).ToString());
        }
        public string ModifyBorehole(Borehole obj)
        {
            return string.Format("修改ID为{0}的钻孔：{1}", obj.ID.ToString(), _boreholeRepository.Update(obj));
        }
    }
}
