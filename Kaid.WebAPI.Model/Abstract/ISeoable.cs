﻿namespace Kaid.WebAPI.Model.Abstract
{
    public interface ISeoable
    {
        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }
    }
}