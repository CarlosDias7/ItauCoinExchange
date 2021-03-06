//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Itau.CoinExchange.Application {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ApplicationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ApplicationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Itau.CoinExchange.Application.ApplicationMessages", typeof(ApplicationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O montante para a conversão deve ser maior que 0 (zero)..
        /// </summary>
        internal static string ConvertCoinBySegmentCommand_Amoun_Less_Than_Zero {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentCommand_Amoun_Less_Than_Zero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A moeda de origem deve ser informada para a conversão..
        /// </summary>
        internal static string ConvertCoinBySegmentCommand_CoinFrom_Is_Empty {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentCommand_CoinFrom_Is_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A moeda de destino deve ser informada para a conversão..
        /// </summary>
        internal static string ConvertCoinBySegmentCommand_CoinTo_Is_Empty {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentCommand_CoinTo_Is_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A data informada para a conversão de moedas é inválida..
        /// </summary>
        internal static string ConvertCoinBySegmentCommand_Date_Is_Invalid {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentCommand_Date_Is_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Não foi possível realizar a conversão solicitada. Por favor tente novamente..
        /// </summary>
        internal static string ConvertCoinBySegmentUseCase_Coin_Convertion_Is_Not_Possible {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentUseCase_Coin_Convertion_Is_Not_Possible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O segmento informado não foi encontrado..
        /// </summary>
        internal static string ConvertCoinBySegmentUseCase_Segment_Not_Found {
            get {
                return ResourceManager.GetString("ConvertCoinBySegmentUseCase_Segment_Not_Found", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O identificador do segmento deve ser informado para a busca..
        /// </summary>
        internal static string GetSegmentByIdQuery_SegmentId_Is_Empty {
            get {
                return ResourceManager.GetString("GetSegmentByIdQuery_SegmentId_Is_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requisição inválida..
        /// </summary>
        internal static string RequestValidationPipeline_Invalid_Request {
            get {
                return ResourceManager.GetString("RequestValidationPipeline_Invalid_Request", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O identificador do segmento deve ser informado para a atualização..
        /// </summary>
        internal static string UpdateSegmentExchageRateCommand_Segment_Id_Is_Empty {
            get {
                return ResourceManager.GetString("UpdateSegmentExchageRateCommand_Segment_Id_Is_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O segmento deve ser informado para a atualização..
        /// </summary>
        internal static string UpdateSegmentExchageRateCommand_Segment_Is_Empty {
            get {
                return ResourceManager.GetString("UpdateSegmentExchageRateCommand_Segment_Is_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O segmento não foi encontrado..
        /// </summary>
        internal static string UpdateSegmentExchangeRateUseCase_Segmento_Not_Found {
            get {
                return ResourceManager.GetString("UpdateSegmentExchangeRateUseCase_Segmento_Not_Found", resourceCulture);
            }
        }
    }
}
