using ManageMiniMart.BLL;
using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart
{
    public partial class FormProduct : Form
    {
        private Form currentChildForm;
        private ProductService productService;
        private CategoryService categoryService;
        public FormProduct()
        {
            InitializeComponent();
            productService = new ProductService();
            categoryService= new CategoryService();
            cbbCategory.DataSource = categoryService.getAllCatogory();
            dgvProduct.DataSource = productService.getAllProduct();
        }
        public void OpenChildForm(Form form) { 
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm= form;
            form.FormBorderStyle= FormBorderStyle.None;
            form.TopLevel = false;
            panelChildFormProduct.Controls.Add(form);
            panelChildFormProduct.Tag= form;
            form.BringToFront();
            form.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Addproduct());
            Addproduct addproduct = new Addproduct();
            addproduct.ShowDialog();
            dgvProduct.DataSource = productService.getAllProduct();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cateId = ((CBBItem)cbbCategory.SelectedItem).Value;
            string productName = txtProductName.Text;
            if(cateId > 0 )
            {
                dgvProduct.DataSource = productService.findByProductNameAndCategory(cateId,productName);
            }
            else
            {
                dgvProduct.DataSource = productService.findByName(productName);
            }
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int cID = ((CBBItem)cbbCategory.SelectedItem).Value;
            if(cID == 0)
            {
                dgvProduct.DataSource = productService.findByName(txtProductName.Text);
            }
            else
            {
                dgvProduct.DataSource = productService.findByProductNameAndCategory(cID,txtProductName.Text);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();

            Product product = productService.findById(Convert.ToInt16(id));
            Addproduct addproduct = new Addproduct();
            addproduct.editProduct(product);
            addproduct.ShowDialog();
            dgvProduct.DataSource = productService.getAllProduct();
        }
    }
}
