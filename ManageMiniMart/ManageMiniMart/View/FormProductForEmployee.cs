using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
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

namespace ManageMiniMart.View
{
    public delegate void ReloadFormProduct();
    public partial class FormProductForEmployee : Form
    {
        private ProductDiscountService productDiscountService;
        private Form currentChildForm;
        private ProductService productService;
        private CategoryService categoryService;
        public FormProductForEmployee()
        {
            InitializeComponent();
            productService = new ProductService();
            categoryService = new CategoryService();
            cbbCategory.DataSource = categoryService.getAllCatogory();
            loadAllProduct();
            productDiscountService = new ProductDiscountService();
        }
        public void OpenChildForm(Form form)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            panelChildFormProduct.Controls.Add(form);
            panelChildFormProduct.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Addproduct());
            Addproduct addproduct = new Addproduct(loadAllProduct);
            addproduct.ShowDialog();
            //loadAllProduct();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cateId = ((CBBItem)cbbCategory.SelectedItem).Value;
            string productName = txtProductName.Text;
            if (cateId > 0)
            {
                dgvProduct.DataSource = productService.findByProductNameAndCategory(cateId, productName);
            }
            else
            {
                dgvProduct.DataSource = productService.findByName(productName);
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int cID = ((CBBItem)cbbCategory.SelectedItem).Value;
            if (cID == 0)
            {
                dgvProduct.DataSource = productService.findByName(txtProductName.Text);
            }
            else
            {
                dgvProduct.DataSource = productService.findByProductNameAndCategory(cID, txtProductName.Text);
            }

        }
        private void loadAllProduct()
        {
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = productService.getAllProduct();
            dgvProduct.RefreshEdit();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();

            Product product = productService.findById(Convert.ToInt16(id));
            Addproduct addproduct = new Addproduct(loadAllProduct);
            addproduct.editProduct(product);
            addproduct.ShowDialog();
            loadAllProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strings = "";
            int i = 0;
            List<int> productId = new List<int>();
            foreach (object s in dgvProduct.SelectedRows)
            {
                strings += dgvProduct.SelectedRows[i].Cells[1].Value.ToString();
                productId.Add(Convert.ToInt32(dgvProduct.SelectedRows[i].Cells[0].Value.ToString()));
                i++;
            }
            MyMessageBox messageBox = new MyMessageBox();
            DialogResult rs = messageBox.show("Are you sure delete " + strings, "Confirm delete", MyMessageBox.TypeMessage.YESNO, MyMessageBox.TypeIcon.QUESTION);

            if (rs == DialogResult.Yes)
            {

                foreach (int id in productId)
                {
                    productService.deleteProduct(id);
                }
            }
            else
            {

            }
            loadAllProduct();
        }
    }
}
