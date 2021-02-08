using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace wpf_demo.Tools
{
    /// <summary>
    /// 类相关帮助类
    /// </summary>
    public class ClassHelper
    {
        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于初始化新实体
        /// </summary>
        /// <typeparam name="D">返回的实体</typeparam>
        /// <typeparam name="S">数据源实体</typeparam>
        /// <param name="s">数据源实体</param>
        /// <returns>返回的新实体</returns>
        public static D Mapper<D, S>(S s)
        {
            D d = Activator.CreateInstance<D>(); //构造新实例
            try
            {
                var Types = s.GetType();//获得类型  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//判断属性名是否相同  
                        {
                            dp.SetValue(d, sp.GetValue(s, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return d;
        }


        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于没有新建实体之间
        /// </summary>
        /// <typeparam name="D">返回的实体</typeparam>
        /// <typeparam name="S">数据源实体</typeparam>
        /// <param name="targetObj">返回的实体</param>
        /// <param name="sourceObj">数据源实体</param>
        /// <returns></returns>
        public static string JsonUpdateObj<T>(string jsonStr, object targetObj)
        {
            string result = string.Empty;   
            try
            {
                JObject sourceTobj = JsonConvert.DeserializeObject<JObject>(jsonStr);
                T sourceObj = JsonConvert.DeserializeObject<T>(jsonStr);
                var sourceTypes = sourceObj.GetType();//获得类型  
                var targetTypes = targetObj.GetType();
                foreach (var item in sourceTobj)
                {
                    foreach (PropertyInfo sourceField in sourceTypes.GetProperties())//获得类型的属性字段  
                    {
                        if (item.Key.Equals(sourceField.Name))
                        {
                            foreach (PropertyInfo targetField in targetTypes.GetProperties())
                            {
                                if (targetField.Name == sourceField.Name && targetField.PropertyType == sourceField.PropertyType)//判断属性名是否相同  
                                {
                                    try
                                    {
                                        targetField.SetValue(targetObj, sourceField.GetValue(sourceObj, null), null);//获得s对象属性的值复制给d对象的属性  
                                    }
                                    catch (Exception ex)
                                    {
                                        result = ex.Message;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result= ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于没有新建实体之间
        /// </summary>
        /// <typeparam name="D">返回的实体</typeparam>
        /// <typeparam name="S">数据源实体</typeparam>
        /// <param name="targetObj">返回的实体</param>
        /// <param name="sourceObj">数据源实体</param>
        /// <returns></returns>
        public static string  MapperToModel(Object sourceObj,object targetObj)
        {
            try
            {
                var sourceTypes = sourceObj.GetType();//获得类型  
                var targetTypes = targetObj.GetType();
                foreach (PropertyInfo sourceField in sourceTypes.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo targetField in targetTypes.GetProperties())
                    {
                        if (targetField.Name == sourceField.Name && targetField.PropertyType == sourceField.PropertyType)//判断属性名是否相同  
                        {
                            try
                            {
                                targetField.SetValue(targetObj, sourceField.GetValue(sourceObj, null), null);//获得s对象属性的值复制给d对象的属性  
                            }
                            catch (Exception)
                            {

                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }


        public Type typen(string typeName)
        {
            Type type = null;
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            int assemblyArrayLength = assemblyArray.Length;
            for (int i = 0; i < assemblyArrayLength; ++i)
            {
                type = assemblyArray[i].GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            for (int i = 0; (i < assemblyArrayLength); ++i)
            {
                Type[] typeArray = assemblyArray[i].GetTypes();
                int typeArrayLength = typeArray.Length;
                for (int j = 0; j < typeArrayLength; ++j)
                {
                    if (typeArray[j].Name.Equals(typeName))
                    {
                        return typeArray[j];
                    }
                }
            }
            return type;
        }
    }
}
