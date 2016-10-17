﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizOneShot.Light.Dao.Infrastructure;
using BizOneShot.Light.Dao.Repositories;
using BizOneShot.Light.Models.WebModels;

namespace BizOneShot.Light.Services
{
    public interface IScMentorMappingService : IBaseService
    {
        // loy make 20160517
        Task<IList<VcMentorMapping>> GetMentorListAsync(string loginId);

        //Task<IList<VcMentorMapping>> GetMentorListAsync(int mngCompSn, int bizWorkSn = 0, string usrTypeDetail = null);
        //Task<VcMentorMapping> GetMentor(int bizWorkSn, string mentorId);
        //Task<IList<VcMentorMapping>> GetMentorMappingListByMentorId(string mentorId = null, int bizWorkYear = 0);
        //Task<IList<VcUsrInfo>> GetMentorListByBizWork(int bizWorkSn);

        //Task<IList<VcUsrInfo>> GetMentorListByBizMng(int mngComSn, string excutorId = null, int bizWorkSn = 0,
        //    int bizWorkYear = 0);

        Task<int> AddMentorAsync(VcCompInfo scCompInfo);

        //IList<VcMentorMapping> GetMentorMappingListByMentorIdSync(string mentorId = null, int bizWorkYear = 0);


        

    }

    public class ScMentorMappingService : IScMentorMappingService
    {
        private readonly IScCompInfoRepository scCompInfoRespository;
        private readonly IScMentorMappingRepository scMentorMappingRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScMentorMappingService(IScMentorMappingRepository scMentorMappingRepository,
            IScCompInfoRepository scCompInfoRespository, IUnitOfWork unitOfWork)
        {
            this.scMentorMappingRepository = scMentorMappingRepository;
            this.scCompInfoRespository = scCompInfoRespository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<VcMentorMapping>> GetMentorListAsync(string baSn)
        {
            IEnumerable<VcMentorMapping> listMentorTask = null;

            var convertBaSn = int.Parse(baSn);

            listMentorTask = await scMentorMappingRepository.GetMentorMappingsAsync(mmp => mmp.BaSn == convertBaSn);
            return listMentorTask.ToList();
        }

        //public async Task<IList<VcMentorMapping>> GetMentorListAsync(int mngCompSn, int bizWorkSn = 0,
        //    string usrTypeDetail = null)
        //{
        //    IEnumerable<VcMentorMapping> listMentorTask = null;
            
        //    if (bizWorkSn == 0 && string.IsNullOrEmpty(usrTypeDetail))
        //    {
        //        listMentorTask =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp => mmp.Status == "N" && mmp.ScUsr.UsrType == "M" && mmp.MngCompSn == mngCompSn);
        //    }
        //    else if (bizWorkSn != 0 && string.IsNullOrEmpty(usrTypeDetail))
        //    {
        //        listMentorTask =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp =>
        //                        mmp.Status == "N" && mmp.ScUsr.UsrType == "M" && mmp.MngCompSn == mngCompSn &&
        //                        mmp.BizWorkSn == bizWorkSn);
        //    }
        //    else if (bizWorkSn == 0 && !string.IsNullOrEmpty(usrTypeDetail))
        //    {
        //        listMentorTask =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp =>
        //                        mmp.Status == "N" && mmp.ScUsr.UsrType == "M" && mmp.MngCompSn == mngCompSn &&
        //                        mmp.ScUsr.UsrTypeDetail == usrTypeDetail);
        //    }
        //    else
        //    {
        //        listMentorTask =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp =>
        //                        mmp.Status == "N" && mmp.ScUsr.UsrType == "M" && mmp.MngCompSn == mngCompSn &&
        //                        mmp.BizWorkSn == bizWorkSn && mmp.ScUsr.UsrTypeDetail == usrTypeDetail);
        //    }
        //    return listMentorTask.OrderByDescending(mmp => mmp.RegDt).ToList();
        //}

        //public async Task<VcMentorMapping> GetMentor(int bizWorkSn, string mentorId)
        //{
        //    var scMentorMapping =
        //        await
        //            scMentorMappingRepository.GetMentorMappingAsync(
        //                smm => smm.BizWorkSn == bizWorkSn && smm.MentorId == mentorId);

        //    return scMentorMapping;
        //}

        //public async Task<IList<VcMentorMapping>> GetMentorMappingListByMentorId(string mentorId, int bizWorkYear = 0)
        //{
        //    var date = DateTime.Now.Date;

        //    var listScMentorMapping =
        //        await
        //            scMentorMappingRepository.GetMentorMappingsAsync(
        //                mmp => mmp.MentorId == mentorId && mmp.Status == "N");

        //    if (bizWorkYear == 0)
        //    {
        //        return listScMentorMapping.Where(mmp => mmp.ScBizWork.BizWorkEdDt.Value >= date).ToList();
        //    }
        //    return listScMentorMapping.Where(mmp => mmp.ScBizWork.BizWorkEdDt.Value >= date)
        //        .Where(
        //            mmp =>
        //                mmp.ScBizWork.BizWorkStDt.Value.Year <= bizWorkYear &&
        //                mmp.ScBizWork.BizWorkEdDt.Value.Year >= bizWorkYear).ToList();
        //}

        //public IList<VcMentorMapping> GetMentorMappingListByMentorIdSync(string mentorId, int bizWorkYear = 0)
        //{
        //    var date = DateTime.Now.Date;

        //    var listScMentorMapping =
        //        scMentorMappingRepository.GetMany(mmp => mmp.MentorId == mentorId && mmp.Status == "N");

        //    return listScMentorMapping.ToList();

        //    if (bizWorkYear == 0)
        //    {
        //        return listScMentorMapping.Where(mmp => mmp.ScBizWork.BizWorkEdDt.Value >= date).ToList();
        //    }
        //    return listScMentorMapping.Where(mmp => mmp.ScBizWork.BizWorkEdDt.Value >= date)
        //        .Where(
        //            mmp =>
        //                mmp.ScBizWork.BizWorkStDt.Value.Year <= bizWorkYear &&
        //                mmp.ScBizWork.BizWorkEdDt.Value.Year >= bizWorkYear).ToList();
        //}


        //public async Task<IList<VcUsrInfo>> GetMentorListByBizWork(int bizWorkSn)
        //{
        //    var listScMentorMapping =
        //        await
        //            scMentorMappingRepository.GetMentorMappingsInScUsrAsync(
        //                mmp => mmp.BizWorkSn == bizWorkSn && mmp.Status == "N");

        //    return listScMentorMapping.Select(mmp => mmp.ScUsr).Distinct().OrderBy(mi => mi.Name).ToList();
        //}

        //public async Task<IList<VcUsrInfo>> GetMentorListByBizMng(int mngComSn, string excutorId = null, int bizWorkSn = 0,
        //    int bizWorkYear = 0)
        //{
        //    if (string.IsNullOrEmpty(excutorId))
        //    {
        //        var listScMentorMapping =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp => mmp.MngCompSn == mngComSn && mmp.Status == "N");

        //        var listMentorInfo =
        //            listScMentorMapping.Where(mmp => bizWorkSn == 0 ? mmp.BizWorkSn > 0 : mmp.BizWorkSn == bizWorkSn)
        //                .Where(
        //                    mmp =>
        //                        bizWorkYear == 0
        //                            ? mmp.ScBizWork.BizWorkStDt.Value.Year > 0
        //                            : mmp.ScBizWork.BizWorkStDt.Value.Year <= bizWorkYear &&
        //                              mmp.ScBizWork.BizWorkEdDt.Value.Year >= bizWorkYear)
        //                .Select(mmp => mmp.ScUsr).Distinct();

        //        return listMentorInfo.OrderBy(mi => mi.Name).ToList();
        //    }
        //    else
        //    {
        //        var listScMentorMapping =
        //            await
        //                scMentorMappingRepository.GetMentorMappingsAsync(
        //                    mmp =>
        //                        mmp.MngCompSn == mngComSn && mmp.ScBizWork.ExecutorId == excutorId && mmp.Status == "N");

        //        var listMentorInfo =
        //            listScMentorMapping.Where(mmp => bizWorkSn == 0 ? mmp.BizWorkSn > 0 : mmp.BizWorkSn == bizWorkSn)
        //                .Where(
        //                    mmp =>
        //                        bizWorkYear == 0
        //                            ? mmp.ScBizWork.BizWorkStDt.Value.Year > 0
        //                            : mmp.ScBizWork.BizWorkStDt.Value.Year <= bizWorkYear &&
        //                              mmp.ScBizWork.BizWorkEdDt.Value.Year >= bizWorkYear)
        //                .Select(mmp => mmp.ScUsr).Distinct();

        //        return listMentorInfo.OrderBy(mi => mi.Name).ToList();
        //    }
        //}

        public async Task<int> AddMentorAsync(VcCompInfo scCompInfo)
        {
            //var rstScUsr = scUsrRespository.Insert(scUsr);
            //scCompInfo.
            var rstScCompInfo = scCompInfoRespository.Insert(scCompInfo);

            if (rstScCompInfo == null)
            {
                return -1;
            }
            return await SaveDbContextAsync();
        }


        public void SaveDbContext()
        {
            unitOfWork.Commit();
        }

        public async Task<int> SaveDbContextAsync()
        {
            return await unitOfWork.CommitAsync();
        }
    }
}