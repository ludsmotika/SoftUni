using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToFind)
    {
        StringBuilder sb= new StringBuilder();
        Type type = Type.GetType(className);
        if (type!=null)
        {
            sb.AppendLine($"Class under investigation: {type.Name}");
        }
        else
        {
            throw new NullReferenceException();
        }
        Object obj=Activator.CreateInstance(type);
        FieldInfo[] fields = type.GetFields((BindingFlags)60);
        foreach (FieldInfo field in fields) 
        {
            if (fieldsToFind.Contains(field.Name))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(obj)}");
            }
        }
        return sb.ToString().Trim();
    }
    public string AnalyzeAccessModifiers(string className) 
    {
        StringBuilder sb=new StringBuilder();
        Type type = Type.GetType(className);
        FieldInfo[] fields = type.GetFields(BindingFlags.Public| BindingFlags.Static | BindingFlags.Instance);
        MethodInfo[] getters = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] setters = type.GetMethods(BindingFlags.Public |  BindingFlags.Instance);
        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var getter in getters.Where(x=>x.Name.Contains("get"))) 
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }
        foreach (var setter in setters.Where(x => x.Name.Contains("set")))
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
    public string RevealPrivateMethods(string className) 
    {
        StringBuilder sb = new StringBuilder();
        Type type= Type.GetType(className);
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic |  BindingFlags.Instance);
        foreach (var item in privateMethods)
        {
            sb.AppendLine(item.Name);
        }
        return sb.ToString().Trim();
    }
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type type = Type.GetType(className);
        MethodInfo[] methods = type.GetMethods((BindingFlags)60);
        foreach (var method in methods)
        {
            if (method.Name.Contains("get"))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            else if (method.Name.Contains("set")) 
            {            
                sb.AppendLine($"{method.Name} will set field of {method.ReturnParameter.Name}");
            }
        }
        return sb.ToString().Trim();
    }
}

