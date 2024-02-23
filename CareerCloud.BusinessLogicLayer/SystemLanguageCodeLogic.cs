﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;


namespace CareerCloud.BusinessLogicLayer;

public class SystemLanguageCodeLogic
{
    protected IDataRepository<SystemLanguageCodePoco> _repository;
    public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
    {
        _repository = repository;
    }
    protected void Verify(SystemLanguageCodePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.LanguageID))
            {
                exceptions.Add(new ValidationException(1000, $"LanguageID for SystemLanguageCodePoco cannot be null or empty"));
            }

            if (string.IsNullOrEmpty(poco.Name))
            {
                exceptions.Add(new ValidationException(1001, $"Name for SystemLanguageCodePoco cannot be null or empty"));
            }

            if (string.IsNullOrEmpty(poco.NativeName))
            {
                exceptions.Add(new ValidationException(1002, $"NativeName for SystemLanguageCodePoco cannot be null or empty"));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public void Add(SystemLanguageCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Add(pocos);

    }

    public void Update(SystemLanguageCodePoco[] pocos)
    {
        Verify(pocos);
        _repository.Update(pocos);
    }

    public virtual SystemLanguageCodePoco Get(string languageID)
    {
        return _repository.GetSingle(c => c.LanguageID == languageID);
    }

    public virtual List<SystemLanguageCodePoco> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public void Delete(SystemLanguageCodePoco[] pocos)
    {
        _repository.Remove(pocos);
    }
}
