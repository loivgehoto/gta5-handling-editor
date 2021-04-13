using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Handling
{
    public partial class Form1 : Form
    {
        private String filePath="null";/*文件路径*/
        private XmlDocument xml;
        private XmlNode name_node;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)/*此按钮位于左上角*/
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())///////////////通过资源管理器选择文件并获取文件路径(openfiledialog)
            {
                openFileDialog.InitialDirectory = "explorer.exe";///////////////
                openFileDialog.Filter = "meta files (*.meta*)|*.meta*";/////////////////设置打开类型名，与文件后缀名，多个类型以|分隔
                openFileDialog.FilterIndex = 2;/////////////
                openFileDialog.RestoreDirectory = true;/////////////


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;///////////////获取文件路径
                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();        
                }
            }
            xml = new XmlDocument();
            if(filePath!="null")/*打开打开文件窗口却没有选择文件，然后关闭窗口，程序发生错误（已解决）没有选择文件，filepath为初始值*/
                xml.Load(filePath);/*加载指定路径的xml*/

            //if (Path.GetFileName(filePath) != "handling.meta")

            name_node = xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/handlingName");/*获取单个节点，括号中为从根节点依次到子节点*/


            if (name_node != null)/*如果用户打开错误的文件，name_node为null指针*/
            {
                filePath_label.Text = "文件路径:" + filePath;////显示文件路径在界面

                showHandlingname.Text = name_node.InnerText;///////////////显示handling文件名到左上角handlingname标签

                XmlNode name_node2 = xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item");/*获取item节点*/
                XmlNodeList other_nodes = name_node2.ChildNodes;//////////////////////////////////////////////！！！！！使用.ChildNodes，才能获取所有item子节点，否则nodelist永远只获取到item自己一个节点

                foreach (XmlNode x in other_nodes)/*用xmlnode代表单个节点来循环遍历nodelist*/
                {
                    switch (x.Name)/*x.name表示该节点的名称或标签*/
                    {
                        case "fMass":
                            fMassvalue_label.Text = x.Attributes["value"].Value; /*Attributes["value"].Value表示获取属性名value的值*/
                            break;
                        case "fInitialDragCoeff":
                            fInitialDragCoeff_label.Text = x.Attributes["value"].Value;
                            break;
                        case "fPercentSubmerged":
                            SUBMERGED_TEXTBOX.Text = x.Attributes["value"].Value;
                            break;
                        case "vecCentreOfMassOffset":
                            textBox0.Text = x.Attributes["x"].Value;
                            textBox1.Text = x.Attributes["y"].Value;
                            textBox2.Text = x.Attributes["z"].Value;
                            break;
                        case "vecInertiaMultiplier":
                            vecInertiaMultiplierx.Text = x.Attributes["x"].Value;
                            vecInertiaMultipliery.Text = x.Attributes["y"].Value;
                            vecInertiaMultiplierz.Text = x.Attributes["z"].Value;
                            break;
                        case "fDriveBiasFront":
                            textBox3.Text = x.Attributes["value"].Value;
                            break;
                        case "nInitialDriveGears":
                            textBox4.Text = x.Attributes["value"].Value;
                            break;
                        case "fInitialDriveForce":
                            textBox5.Text = x.Attributes["value"].Value;
                            break;
                        case "fDriveInertia":
                            textBox6.Text = x.Attributes["value"].Value;
                            break;
                        case "fClutchChangeRateScaleUpShift":
                            textBox7.Text = x.Attributes["value"].Value;
                            break;
                        case "fClutchChangeRateScaleDownShift":
                            textBox8.Text = x.Attributes["value"].Value;
                            break;
                        case "fInitialDriveMaxFlatVel":
                            textBox9.Text = x.Attributes["value"].Value;
                            break;
                        case "fBrakeForce":
                            textBox10.Text = x.Attributes["value"].Value;
                            break;
                        case "fBrakeBiasFront":
                            textBox11.Text = x.Attributes["value"].Value;
                            break;
                        case "fHandBrakeForce":
                            textBox12.Text = x.Attributes["value"].Value;
                            break;
                        case "fSteeringLock":
                            textBox13.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionCurveMax":
                            textBox14.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionCurveMin":
                            textBox15.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionCurveLateral":
                            textBox16.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionSpringDeltaMax":
                            textBox17.Text = x.Attributes["value"].Value;
                            break;
                        case "fLowSpeedTractionLossMult":
                            textBox18.Text = x.Attributes["value"].Value;
                            break;
                        case "fCamberStiffnesss":
                            textBox19.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionBiasFront":
                            textBox20.Text = x.Attributes["value"].Value;
                            break;
                        case "fTractionLossMult":
                            textBox21.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionForce":
                            textBox22.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionCompDamp":
                            textBox23.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionReboundDamp":
                            textBox24.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionUpperLimit":
                            textBox25.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionLowerLimit":
                            textBox26.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionRaise":
                            textBox27.Text = x.Attributes["value"].Value;
                            break;
                        case "fSuspensionBiasFront":
                            textBox28.Text = x.Attributes["value"].Value;
                            break;
                        case "fAntiRollBarForce":
                            textBox29.Text = x.Attributes["value"].Value;
                            break;
                        case "fAntiRollBarBiasFront":
                            textBox30.Text = x.Attributes["value"].Value;
                            break;
                        case "fRollCentreHeightFront":
                            textBox31.Text = x.Attributes["value"].Value;
                            break;
                        case "fRollCentreHeightRear":
                            textBox32.Text = x.Attributes["value"].Value;
                            break;
                        case "fCollisionDamageMult":
                            textBox33.Text = x.Attributes["value"].Value;
                            break;
                        case "fWeaponDamageMult":
                            textBox34.Text = x.Attributes["value"].Value;
                            break;
                        case "fDeformationDamageMult":
                            textBox35.Text = x.Attributes["value"].Value;
                            break;
                        case "fEngineDamageMult":
                            textBox36.Text = x.Attributes["value"].Value;
                            break;
                        case "fPetrolTankVolume":
                            textBox37.Text = x.Attributes["value"].Value;
                            break;

                    }
                }
            }
            else
            {
                MessageBox.Show("请导入正确的文件");/*导入错误文件*/
            }
        }
        private void apply_button_Click(object sender, EventArgs e)/*此方法为将每个textbox的文本信息保存至xml当中的指定节点*/
        {
            if(filePath!="null"&&name_node!=null)/*先打开正确格式的文档后再打开错误格式的文档，程序弹出错误提示框后，用户点击保存，会发生空指针错误，增加空指针判定语句*/
            {
                XmlElement n= (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fMass");
                n.SetAttribute("value", fMassvalue_label.Text);

                XmlElement n2 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fInitialDragCoeff");
                n2.SetAttribute("value", fInitialDragCoeff_label.Text);

                XmlElement n3 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fPercentSubmerged");
                n3.SetAttribute("value", SUBMERGED_TEXTBOX.Text);

                XmlElement n4 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/vecCentreOfMassOffset");
                n4.SetAttribute("x", textBox0.Text);
                n4.SetAttribute("y", textBox1.Text);
                n4.SetAttribute("z", textBox2.Text);

                XmlElement n42 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/vecInertiaMultiplier");
                n42.SetAttribute("x", vecInertiaMultiplierx.Text);
                n42.SetAttribute("y", vecInertiaMultipliery.Text);
                n42.SetAttribute("z", vecInertiaMultiplierz.Text);

                XmlElement n5 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fDriveBiasFront");
                n5.SetAttribute("value", textBox3.Text);

                XmlElement n6 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/nInitialDriveGears");
                n6.SetAttribute("value", textBox4.Text);

                XmlElement n7 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fInitialDriveForce");
                n7.SetAttribute("value", textBox5.Text);

                XmlElement n8 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fDriveInertia");
                n8.SetAttribute("value", textBox6.Text);

                XmlElement n9 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fClutchChangeRateScaleUpShift");
                n9.SetAttribute("value", textBox7.Text);

                XmlElement n10 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fClutchChangeRateScaleDownShift");
                n10.SetAttribute("value", textBox8.Text);

                XmlElement n11 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fInitialDriveMaxFlatVel");
                n11.SetAttribute("value", textBox9.Text);

                XmlElement n12 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fBrakeForce");
                n12.SetAttribute("value", textBox10.Text);

                XmlElement n13 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fBrakeBiasFront");
                n13.SetAttribute("value", textBox11.Text);

                XmlElement n14 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fHandBrakeForce");
                n14.SetAttribute("value", textBox12.Text);

                XmlElement n15 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSteeringLock");
                n15.SetAttribute("value", textBox13.Text);

                XmlElement n16 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionCurveMax");
                n16.SetAttribute("value", textBox14.Text);

                XmlElement n17 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionCurveMin");
                n17.SetAttribute("value", textBox15.Text);

                XmlElement n18 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionCurveLateral");
                n18.SetAttribute("value", textBox16.Text);

                XmlElement n19 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionSpringDeltaMax");
                n19.SetAttribute("value", textBox17.Text);

                XmlElement n20 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fLowSpeedTractionLossMult");
                n16.SetAttribute("value", textBox18.Text);

                XmlElement n21 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fCamberStiffnesss");
                n21.SetAttribute("value", textBox19.Text);

                XmlElement n22 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionBiasFront");
                n22.SetAttribute("value", textBox20.Text);

                XmlElement n23 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fTractionLossMult");
                n23.SetAttribute("value", textBox21.Text);

                XmlElement n24 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionForce");
                n24.SetAttribute("value", textBox22.Text);

                XmlElement n25 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionCompDamp");
                n25.SetAttribute("value", textBox23.Text);

                XmlElement n26 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionReboundDamp");
                n26.SetAttribute("value", textBox24.Text);

                XmlElement n27 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionUpperLimit");
                n27.SetAttribute("value", textBox25.Text);

                XmlElement n28 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionLowerLimit");
                n28.SetAttribute("value", textBox26.Text);

                XmlElement n29 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionRaise");
                n29.SetAttribute("value", textBox27.Text);

                XmlElement n30 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fSuspensionBiasFront");
                n30.SetAttribute("value", textBox28.Text);

                XmlElement n31 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fAntiRollBarForce");
                n31.SetAttribute("value", textBox29.Text);

                XmlElement n32 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fAntiRollBarBiasFront");
                n32.SetAttribute("value", textBox30.Text);

                XmlElement n33 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fRollCentreHeightFront");
                n33.SetAttribute("value", textBox31.Text);

                XmlElement n34 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fRollCentreHeightRear");
                n34.SetAttribute("value", textBox32.Text);

                XmlElement n35 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fCollisionDamageMult");
                n35.SetAttribute("value", textBox33.Text);

                XmlElement n36 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fWeaponDamageMult");
                n36.SetAttribute("value", textBox34.Text);

                XmlElement n37 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fDeformationDamageMult");
                n37.SetAttribute("value", textBox35.Text);

                XmlElement n38 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fEngineDamageMult");
                n38.SetAttribute("value", textBox36.Text);

                XmlElement n39 = (XmlElement)xml.SelectSingleNode("/CHandlingDataMgr/HandlingData/Item/fPetrolTankVolume");
                n39.SetAttribute("value", textBox37.Text);

   

                MessageBox.Show("修改成功");
                xml.Save(filePath);//////保存更改
            }
        }

    }
}
