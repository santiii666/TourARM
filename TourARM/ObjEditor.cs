using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAVCSLib
{
    public interface IFormEditor
    {
        void initEditor(Object obj);
        bool Exec();
    }

    public class ObjEditor
    {
        public static void Form2Obj(Form fm, Object obj)
        {
            System.Reflection.MemberInfo[] memberlist = obj.GetType().GetMembers();
            for (int i = 0; i < memberlist.Length; i++)
            {
                if (memberlist[i].MemberType == System.Reflection.MemberTypes.Field)

                    if (fm.Controls["text" + memberlist[i].Name] != null)
                    {
                        System.Reflection.FieldInfo fi = obj.GetType().GetField(memberlist[i].Name) ;
                        string str = fm.Controls["text" + memberlist[i].Name].Text.Trim();
                        if (fi.FieldType.Equals(typeof(string))) fi.SetValue(obj,str);
                        if (fi.FieldType.Equals(typeof(int)))
                        {
                            int n ;
                            if (Int32.TryParse(str,out n)) fi.SetValue(obj, n);
                        }
                            
                    }
                    
            }
        }

        public static void Obj2Form(Form fm, Object obj)
        {
            System.Reflection.MemberInfo[] memberlist = obj.GetType().GetMembers();
            for (int i = 0; i < memberlist.Length; i++)
            {
                if (memberlist[i].MemberType == System.Reflection.MemberTypes.Field)

                    if (fm.Controls["text" + memberlist[i].Name] != null)
                    {
                        Object O = obj.GetType().GetField(memberlist[i].Name).GetValue(obj);
                        string str = "";
                        if (O != null) {
                            if (O.GetType().Equals(typeof(string))) str = (string)O;
                            if (O.GetType().Equals(typeof(int))) str=((int)O).ToString("D") ;
                        }
                        fm.Controls["text" + memberlist[i].Name].Text = str;
                    }

            }
        }
    }
}
