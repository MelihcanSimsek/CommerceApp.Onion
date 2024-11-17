﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CommerceApp.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest: IRequest<IList<GetAllProductsQueryResponse>>
    {

    }
}
