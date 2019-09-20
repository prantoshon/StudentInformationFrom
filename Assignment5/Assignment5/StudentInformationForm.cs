using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class StudentInformationForm : Form
    {
        List<string> id = new List<string> { };
        List<string> name = new List<string> { };
        List<string> mobile = new List<string> { };
        List<string> age = new List<string> { };
        List<string> address = new List<string> { };
        List<double> gpaPoint = new List<double> { };
        
        string nameOfMaximumGpaStudent;
        string nameOfMinimumGpaStudent;
       

        public StudentInformationForm()
        {
            InitializeComponent();
           
        }

        private void StudentInformationForm_Load(object sender, EventArgs e)
        {

        }

        private void AddAllInformation() 
        {
            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
                if (idTextBox.Text.Length == 4)
                {

                    if (!id.Contains(idTextBox.Text))
                    {

                        if (!String.IsNullOrEmpty(nameTextBox.Text))
                        {
                            if (!System.Text.RegularExpressions.Regex.IsMatch(nameTextBox.Text, "[^a-zA-Z ]"))
                            {
                                if (!String.IsNullOrEmpty(mobileTextBox.Text))
                                {
                                  
                                      
                                        if(!System.Text.RegularExpressions.Regex.IsMatch(mobileTextBox.Text, "[^0-9]"))
                                        {
                                            if (mobileTextBox.Text.Length == 11)
                                            {

                                             if (!mobile.Contains((mobileTextBox.Text)))
                                             {
                                                  
                                                 
                                                         resultRichTextBox.Clear();
                                                         try
                                                         {
                                                             
                                                             id.Add(idTextBox.Text);
                                                             name.Add(nameTextBox.Text);
                                                             mobile.Add((mobileTextBox.Text));
                                                             age.Add((ageTextBox.Text));
                                                             address.Add(adddressTextBox.Text);
                                                             gpaPoint.Add(Convert.ToDouble(gpaNumericUpDown.Value));

                                                             resultRichTextBox.Text += "ID :" + idTextBox.Text + " " + " Name :" + nameTextBox.Text + " " + "Mobile : " + mobileTextBox.Text + " " + " Age : " + ageTextBox.Text + " " + " Address :" + adddressTextBox.Text + " " + "GPA : " + gpaNumericUpDown.Value + " \n";
                                                             idTextBox.Clear();
                                                             nameTextBox.Clear();
                                                             mobileTextBox.Clear();
                                                             ageTextBox.Clear();
                                                             adddressTextBox.Clear();
                                                             
                                                             
                                                             

                                                         
                                                         }
                                                         catch(Exception c) 
                                                         {
                                                             MessageBox.Show(c.Message);
                                                         
                                                         }


                                                 }
                                                    
                                              
                                              
                                             
                                           else
                                                 {
                                                 MessageBox.Show("Mobile Number is Duplicate", "Wraning");
                                                  return;
                                                  }
                                                }
                                              else
                                              {
                                                 MessageBox.Show("Mobile number should be is 11 digit", "Wrning");
                                                 return;
                                         
                                             }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid Mobile Number", "Wrning");
                                            return;
                                         
                                        }
                                      
                                    }
                                   
                                
                                else 
                                {
                                    MessageBox.Show("Mobile Number is Required", "Wraning");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Name  should be on character only", "Wraning");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Name is Required", "Wraning");
                            return;
                        }



                    }
                    else 
                    {
                        MessageBox.Show("Id is Duplicate", "Wraning");
                        return;
                    }
                }
                else 
                {
                    MessageBox.Show("Id is miniMum 4 Digit", "Wraning");
                    return;
                }
            }
            else 
            {
                MessageBox.Show("Id is Required","Wraning");
                return;
            }
        }

        private void MaxCalculate() 
        {
            double max = gpaPoint[0];
            
            
            for (int i = 0; i < id.Count(); i++) 
            {
                if (max <= gpaPoint[i]) 
                {
                    max = gpaPoint[i];
                    nameOfMaximumGpaStudent = name[i];
                }
               
            }

            maxTextBox.Text = max.ToString();
            maxNameTextBox.Text = nameOfMaximumGpaStudent.ToString();
        
        }

        private void MiniCalculate() 
        {
            double min = gpaPoint[0];
            for (int i = 0; i < id.Count(); i++) 
            {
                if (min >= gpaPoint[i]) 
                {
                    min = gpaPoint[i];
                    nameOfMinimumGpaStudent = name[i];

                }
              
            }

            minTextBox.Text = min.ToString();
            minNameTextBox.Text = nameOfMinimumGpaStudent.ToString();
        }


        private void AvgCount() 
        {
            double avg, sum = 0 , count = 0;
            for (int i = 0; i < id.Count(); i++)
            {
                sum = sum + gpaPoint[i];
                count++;
            }
            avg = sum / count;

           
            avgTextBox.Text = avg.ToString();
            totalTextBox.Text = sum.ToString();
        }

        private void SearchInfo() 
        {
            
            if (idRadioButton.Checked)
            {
                string idFind = idTextBox.Text;
                for (int i = 0; i < id.Count(); i++) 
                {
                    if (idFind == id[i])
                    {
                        resultRichTextBox.Text += "id :" + id[i] + " " + "name " + name[i] + " " + "Mobile Number :" + mobile[i] + " " + "Age :" + age[i] + " " + " GPA :" + gpaPoint[i] + " Address :" + address[i] + "\n";


                    }
                   
                    

                    idTextBox.Clear();
                }

            }
            else if(nameRadioButton.Checked) 
            {
                string nameFind = nameTextBox.Text;
                for (int i = 0; i < name.Count(); i++)
                {
                    if (nameFind == name[i])
                    {
                        resultRichTextBox.Text += "id :" + id[i] + " " + "name " + name[i] + " " + "Mobile Number :" + mobile[i] + " " + "Age " + age[i] + " " + " GPA :" + gpaPoint[i] + " Address :" + address[i] + "\n ";
                    }
                    
                   
                    nameTextBox.Clear();
                }
            }
            else if (mobileRadioButton.Checked)
            {
                string mobileNumberFind = mobileTextBox.Text;
                for (int i = 0; i < mobile.Count(); i++)
                {
                    if (mobileNumberFind == mobile[i])
                    {
                        resultRichTextBox.Text += "id :" + id[i] + " " + "name " + name[i] + " " + "Mobile Number :" + mobile[i] + " " + "Age " + age[i] + " " + " GPA :" + gpaPoint[i] + " Address :" + address[i] + " \n";

                        
                    }

                  
                    mobileTextBox.Clear();
                }

            }
            else 
            {
                MessageBox.Show("Select One Please");
                return;
            }

        }


        private void addButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Clear();
            AddAllInformation();
          
         
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Clear();
            MaxCalculate();
            MiniCalculate();
            AvgCount();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultRichTextBox.Clear();

            SearchInfo();
        }
    }
}
