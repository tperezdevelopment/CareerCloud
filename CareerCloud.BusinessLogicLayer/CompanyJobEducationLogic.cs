﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
{
    public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository) { }

    protected override void Verify(CompanyJobEducationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length < 2)
            {
                exceptions.Add(new ValidationException(200, $"Major for CompanyJobEducationPoco {poco.Id} must be at least 2 characteres"));
            }
            if (poco.Importance < 0)
            {
                exceptions.Add(new ValidationException(201, $"Importance for CompanyJobEducationPoco {poco.Id} cannot be less than 0"));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }



}