using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Itau.CoinExchange.Utils.Objects
{
    public static class ObjectExtensions
    {
        public static object GetProperty(this object obj, string member)
        {
            if (obj == null) throw new ArgumentNullException("o");
            if (member == null) throw new ArgumentNullException("member");
            Type scope = obj.GetType();
            IDynamicMetaObjectProvider provider = obj as IDynamicMetaObjectProvider;
            if (provider != null)
            {
                ParameterExpression param = Expression.Parameter(typeof(object));
                DynamicMetaObject mobj = provider.GetMetaObject(param);
                GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null) });
                DynamicMetaObject ret = mobj.BindGetMember(binder);
                BlockExpression final = Expression.Block(
                    Expression.Label(CallSiteBinder.UpdateLabel),
                    ret.Expression
                );
                LambdaExpression lambda = Expression.Lambda(final, param);
                Delegate del = lambda.Compile();
                return del.DynamicInvoke(obj);
            }
            else
            {
                return obj.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(obj, null);
            }
        }
    }
}