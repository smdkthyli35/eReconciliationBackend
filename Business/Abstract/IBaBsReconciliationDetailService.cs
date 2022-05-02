﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaBsReconciliationDetailService
    {
        IResult Add(BaBsReconciliationDetail baBsReconciliationDetail);
        IResult AddToExcel(string filePath, int baBsReconciliationId);
        IResult Update(BaBsReconciliationDetail baBsReconciliationDetail);
        IResult Delete(BaBsReconciliationDetail baBsReconciliationDetail);
        IDataResult<BaBsReconciliationDetail> GetById(int id);
        IDataResult<List<BaBsReconciliationDetail>> GetAll(int baBsReconciliationId);
    }
}
