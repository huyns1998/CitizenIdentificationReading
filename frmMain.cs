using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Xceed.Words.NET;
using CitizenIdentificationReading.Services;
using CitizenIdentificationReading.Constants;
using CitizenIdentificationReading.Forms;
using System.Threading;
using System.IO;

namespace CitizenIdentificationReading
{
    public partial class frmMain : Form
    {
        private readonly ICccdReaderService _cccdReaderService;
        private CancellationTokenSource? _cts;

        public frmMain(ICccdReaderService cccdReaderService)
        {
            _cccdReaderService = cccdReaderService;
            InitializeComponent();

            // Initialize ComboBox
            cboPaperType.SelectedIndex = 0; // Default to Option 1
        }

        private void SetProcessingState(bool isProcessing)
        {
            int selectedIndex = cboPaperType.SelectedIndex;

            // Disable/Enable inputs
            txtPathToCccd.Enabled = !isProcessing;
            btnSelectCCCDFolder.Enabled = !isProcessing;
            txtSaveFolder.Enabled = !isProcessing;
            btnSaveFolder.Enabled = !isProcessing;
            txtDocPath.Enabled = !isProcessing;
            btnBrowseDoc.Enabled = !isProcessing;

            txtPathToCccdDeligationPaper.Enabled = !isProcessing;
            btnSelectCCCDFolderDeligationPaper.Enabled = !isProcessing;
            txtSaveFolderDeligationPaper.Enabled = !isProcessing;
            btnSaveFolderDeligationPaper.Enabled = !isProcessing;

            txtPathToCccdLandTransfer.Enabled = !isProcessing;
            btnSelectCCCDFolderLandTransfer.Enabled = !isProcessing;
            txtSaveFolderLandTransfer.Enabled = !isProcessing;
            btnSaveFolderLandTransfer.Enabled = !isProcessing;

            txtPathToCccdLandChange.Enabled = !isProcessing;
            btnSelectCCCDFolderLandChange.Enabled = !isProcessing;
            txtSaveFolderLandChange.Enabled = !isProcessing;
            btnSaveFolderLandChange.Enabled = !isProcessing;

            txtPathToCccdLandUseChange.Enabled = !isProcessing;
            btnSelectCCCDFolderLandUseChange.Enabled = !isProcessing;
            txtSaveFolderLandUseChange.Enabled = !isProcessing;
            btnSaveFolderLandUseChange.Enabled = !isProcessing;

            txtPathToCccdAttachedLand.Enabled = !isProcessing;
            btnSelectCCCDFolderAttachedLand.Enabled = !isProcessing;
            txtSaveFolderAttachedLand.Enabled = !isProcessing;
            btnSaveFolderAttachedLand.Enabled = !isProcessing;

            cboPaperType.Enabled = !isProcessing;
            chkInputIssuePlaceLandTransfer.Enabled = !isProcessing;
            chkInputPhoneEmailLandChange.Enabled = !isProcessing;
            chkInputContactLandUseChange.Enabled = !isProcessing;
            chkInputPhoneEmailAttachedLand.Enabled = !isProcessing;

            if (selectedIndex == 5) // Option 2 (Tự chọn mẫu giấy tờ, now final in list)
            {
                btnScan.Enabled = !isProcessing;
                btnScan.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancel.Enabled = isProcessing;
                btnCancel.Visible = true;
                btnReset.Enabled = !isProcessing;
            }
            else if (selectedIndex == 0) // Option 1 (Giấy ủy quyền)
            {
                btnScanDeligationPaper.Enabled = !isProcessing;
                btnScanDeligationPaper.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancelDeligationPaper.Enabled = isProcessing;
                btnCancelDeligationPaper.Visible = true;
                btnResetDeligationPaper.Enabled = !isProcessing;
            }
            else if (selectedIndex == 1) // Option 3 (Hợp đồng chuyển nhượng...)
            {
                btnScanLandTransfer.Enabled = !isProcessing;
                btnScanLandTransfer.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancelLandTransfer.Enabled = isProcessing;
                btnCancelLandTransfer.Visible = true;
                btnResetLandTransfer.Enabled = !isProcessing;
            }
            else if (selectedIndex == 2) // Option 4 (Đơn đăng ký biến động..., was 3)
            {
                btnScanLandChange.Enabled = !isProcessing;
                btnScanLandChange.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancelLandChange.Enabled = isProcessing;
                btnCancelLandChange.Visible = true;
                btnResetLandChange.Enabled = !isProcessing;
            }
            else if (selectedIndex == 3) // Option 5 (Đơn đề nghị chuyển mục đích sử dụng đất)
            {
                btnScanLandUseChange.Enabled = !isProcessing;
                btnScanLandUseChange.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancelLandUseChange.Enabled = isProcessing;
                btnCancelLandUseChange.Visible = true;
                btnResetLandUseChange.Enabled = !isProcessing;
            }
            else if (selectedIndex == 4) // Option 6 (Đơn đăng ký đất đai, tài sản gắn liền với đất)
            {
                btnScanAttachedLand.Enabled = !isProcessing;
                btnScanAttachedLand.Text = isProcessing ? "Đang quét ccccd..." : "Quét cccd";
                btnCancelAttachedLand.Enabled = isProcessing;
                btnCancelAttachedLand.Visible = true;
                btnResetAttachedLand.Enabled = !isProcessing;
            }

            if (!isProcessing)
            {
                // Re-evaluate scan button enabled state based on paths
                if (selectedIndex == 5) UpdateScanButtonState();
                else if (selectedIndex == 0) btnScanDeligationPaper.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdDeligationPaper.Text) && !string.IsNullOrWhiteSpace(txtSaveFolderDeligationPaper.Text);
                else if (selectedIndex == 1) btnScanLandTransfer.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandTransfer.Text) && !string.IsNullOrWhiteSpace(txtSaveFolderLandTransfer.Text);
                else if (selectedIndex == 2) btnScanLandChange.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandChange.Text) && !string.IsNullOrWhiteSpace(txtSaveFolderLandChange.Text);
                else if (selectedIndex == 3) btnScanLandUseChange.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandUseChange.Text) && !string.IsNullOrWhiteSpace(txtSaveFolderLandUseChange.Text);
                else if (selectedIndex == 4) btnScanAttachedLand.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdAttachedLand.Text) && !string.IsNullOrWhiteSpace(txtSaveFolderAttachedLand.Text);
            }
        }

        private void LogAndSaveResult(string message, string savePath, RichTextBox targetRichTextBox, bool isError = false)
        {
            string logMessage = $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";

            // Update UI
            if (targetRichTextBox.InvokeRequired)
            {
                targetRichTextBox.Invoke(new Action(() => 
                {
                    targetRichTextBox.SelectionStart = targetRichTextBox.TextLength;
                    targetRichTextBox.SelectionLength = 0;
                    targetRichTextBox.SelectionColor = isError ? Color.Red : targetRichTextBox.ForeColor;
                    targetRichTextBox.AppendText(logMessage);
                    targetRichTextBox.SelectionColor = targetRichTextBox.ForeColor;
                    targetRichTextBox.ScrollToCaret();
                }));
            }
            else
            {
                targetRichTextBox.SelectionStart = targetRichTextBox.TextLength;
                targetRichTextBox.SelectionLength = 0;
                targetRichTextBox.SelectionColor = isError ? Color.Red : targetRichTextBox.ForeColor;
                targetRichTextBox.AppendText(logMessage);
                targetRichTextBox.SelectionColor = targetRichTextBox.ForeColor;
                targetRichTextBox.ScrollToCaret();
            }

            // Save to file
            try
            {
                string logFileName = $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt";
                // We want to keep the same log file for the entire session if possible, 
                // but the requirement says log_ddMMyyyyHHmmss which usually implies a new file or timestamped.
                // Let's use a consistent filename for the current process run if we want to export at the end,
                // OR append to a timestamped file created at start.

                // Let's assume we create one log file per scan button click.
                // I'll handle the filename creation in the click handlers to keep it consistent for one session.
                if (!string.IsNullOrEmpty(savePath))
                {
                    File.AppendAllText(savePath, logMessage);
                }
            }
            catch { /* Ignore log saving errors */ }
        }

        private void btnSelectCCCDFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccd.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccd.Text;
            string savePath = txtSaveFolder.Text;
            string docPath = txtDocPath.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(docPath))
            {
                MessageBox.Show("File document không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCD.Clear();

            try
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var files = Directory.GetFiles(cccdPath)
                    .Where(file => allowedExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .ToList();

                if (files.Count == 0)
                {
                    MessageBox.Show("Không có ảnh nào trong folder cccd bạn chọn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var file in files)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    try
                    {
                        var result = await _cccdReaderService.ScanCccdAsync(file);
                        if (result != null && result.Success && result.Data != null)
                        {
                            // Fill Word template
                            string templateName = Path.GetFileNameWithoutExtension(docPath);
                            string baseFileName = $"{templateName}_{result.Data.FullName}_{result.Data.CccdNumber}";
                            foreach (char c in Path.GetInvalidFileNameChars())
                            {
                                baseFileName = baseFileName.Replace(c, '_');
                            }

                            string docExtension = Path.GetExtension(docPath);
                            string docFileName = baseFileName + docExtension;
                            string docSavePath = Path.Combine(savePath, docFileName);

                            FillWordTemplate(docPath, docSavePath, result.Data);
                            LogAndSaveResult($"Đã quét và xuất file: {docFileName}", "", txtErrorCCCD);
                        }
                        else
                        {
                            LogAndSaveResult($"Không thể đọc ảnh: {Path.GetFileName(file)}", logFilePath, txtErrorCCCD, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogAndSaveResult($"Lỗi khi xử lý {Path.GetFileName(file)}: {ex.Message}", logFilePath, txtErrorCCCD, true);
                    }

                    await Task.Delay(500);
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCD, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCD);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void txtPaths_TextChanged(object sender, EventArgs e)
        {
            UpdateScanButtonState();
        }

        private void UpdateScanButtonState()
        {
            btnScan.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccd.Text) &&
                              !string.IsNullOrWhiteSpace(txtSaveFolder.Text) &&
                              !string.IsNullOrWhiteSpace(txtDocPath.Text);
        }

        private void btnBrowseDoc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Word Documents (*.doc;*.docx)|*.doc;*.docx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDocPath.Text = ofd.FileName;
                }
            }
        }

        private void cboPaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cboPaperType.SelectedIndex;
            
            // Option 2: Tự chọn mẫu giấy tờ (now final at index 5)
            bool showCustomTemplate = selectedIndex == 5;
            txtPathToCccd.Visible = showCustomTemplate;
            btnSelectCCCDFolder.Visible = showCustomTemplate;
            txtSaveFolder.Visible = showCustomTemplate;
            btnSaveFolder.Visible = showCustomTemplate;
            txtDocPath.Visible = showCustomTemplate;
            btnBrowseDoc.Visible = showCustomTemplate;
            btnScan.Visible = showCustomTemplate;
            label1.Visible = showCustomTemplate;
            txtErrorCCCD.Visible = showCustomTemplate;
            btnCancel.Visible = showCustomTemplate;
            btnReset.Visible = showCustomTemplate;
            
            // Option 1: Giấy ủy quyền
            bool showDeligationPaper = selectedIndex == 0;
            txtPathToCccdDeligationPaper.Visible = showDeligationPaper;
            btnSelectCCCDFolderDeligationPaper.Visible = showDeligationPaper;
            txtSaveFolderDeligationPaper.Visible = showDeligationPaper;
            btnSaveFolderDeligationPaper.Visible = showDeligationPaper;
            btnScanDeligationPaper.Visible = showDeligationPaper;
            label1DeligationPaper.Visible = showDeligationPaper;
            txtErrorCCCDDeligationPaper.Visible = showDeligationPaper;
            btnCancelDeligationPaper.Visible = showDeligationPaper;
            btnResetDeligationPaper.Visible = showDeligationPaper;

            // Option 3: Hợp đồng chuyển nhượng quyền sử dụng đất
            bool showLandTransfer = selectedIndex == 1;
            txtPathToCccdLandTransfer.Visible = showLandTransfer;
            btnSelectCCCDFolderLandTransfer.Visible = showLandTransfer;
            txtSaveFolderLandTransfer.Visible = showLandTransfer;
            btnSaveFolderLandTransfer.Visible = showLandTransfer;
            btnScanLandTransfer.Visible = showLandTransfer;
            label1LandTransfer.Visible = showLandTransfer;
            txtErrorCCCDLandTransfer.Visible = showLandTransfer;
            btnCancelLandTransfer.Visible = showLandTransfer;
            btnResetLandTransfer.Visible = showLandTransfer;
            chkInputIssuePlaceLandTransfer.Visible = showLandTransfer;

            // Option 4: Đơn đăng ký biến động đất đai (now at index 2)
            bool showLandChange = selectedIndex == 2;
            txtPathToCccdLandChange.Visible = showLandChange;
            btnSelectCCCDFolderLandChange.Visible = showLandChange;
            txtSaveFolderLandChange.Visible = showLandChange;
            btnSaveFolderLandChange.Visible = showLandChange;
            btnScanLandChange.Visible = showLandChange;
            label1LandChange.Visible = showLandChange;
            txtErrorCCCDLandChange.Visible = showLandChange;
            btnCancelLandChange.Visible = showLandChange;
            btnResetLandChange.Visible = showLandChange;
            chkInputPhoneEmailLandChange.Visible = showLandChange;

            // Option 5: Đơn đề nghị chuyển mục đích sử dụng đất (now at index 3)
            bool showLandUseChange = selectedIndex == 3;
            txtPathToCccdLandUseChange.Visible = showLandUseChange;
            btnSelectCCCDFolderLandUseChange.Visible = showLandUseChange;
            txtSaveFolderLandUseChange.Visible = showLandUseChange;
            btnSaveFolderLandUseChange.Visible = showLandUseChange;
            btnScanLandUseChange.Visible = showLandUseChange;
            label1LandUseChange.Visible = showLandUseChange;
            txtErrorCCCDLandUseChange.Visible = showLandUseChange;
            btnCancelLandUseChange.Visible = showLandUseChange;
            btnResetLandUseChange.Visible = showLandUseChange;
            chkInputContactLandUseChange.Visible = showLandUseChange;

            // Option 6: Đơn đăng ký đất đai, tài sản gắn liền với đất (now at index 4)
            bool showAttachedLand = selectedIndex == 4;
            txtPathToCccdAttachedLand.Visible = showAttachedLand;
            btnSelectCCCDFolderAttachedLand.Visible = showAttachedLand;
            txtSaveFolderAttachedLand.Visible = showAttachedLand;
            btnSaveFolderAttachedLand.Visible = showAttachedLand;
            btnScanAttachedLand.Visible = showAttachedLand;
            label1AttachedLand.Visible = showAttachedLand;
            txtErrorCCCDAttachedLand.Visible = showAttachedLand;
            btnCancelAttachedLand.Visible = showAttachedLand;
            btnResetAttachedLand.Visible = showAttachedLand;
            chkInputPhoneEmailAttachedLand.Visible = showAttachedLand;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPathToCccd.Clear();
            txtSaveFolder.Clear();
            txtDocPath.Clear();
            txtErrorCCCD.Clear();
        }

        private void btnResetDeligationPaper_Click(object sender, EventArgs e)
        {
            txtPathToCccdDeligationPaper.Clear();
            txtSaveFolderDeligationPaper.Clear();
            txtErrorCCCDDeligationPaper.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCD, true);
            btnCancel.Enabled = false;
        }

        private void btnCancelDeligationPaper_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCDDeligationPaper, true);
            btnCancelDeligationPaper.Enabled = false;
        }

        private void btnSelectCCCDFolderDeligationPaper_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccdDeligationPaper.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolderDeligationPaper_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolderDeligationPaper.Text = fbd.SelectedPath;
                }
            }
        }

        private void txtPathsDeligationPaper_TextChanged(object sender, EventArgs e)
        {
            btnScanDeligationPaper.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdDeligationPaper.Text) &&
                                   !string.IsNullOrWhiteSpace(txtSaveFolderDeligationPaper.Text);
        }

        private void btnSelectCCCDFolderLandTransfer_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccdLandTransfer.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolderLandTransfer_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolderLandTransfer.Text = fbd.SelectedPath;
                }
            }
        }

        private void txtPathsLandTransfer_TextChanged(object sender, EventArgs e)
        {
            btnScanLandTransfer.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandTransfer.Text) &&
                                   !string.IsNullOrWhiteSpace(txtSaveFolderLandTransfer.Text);
        }

        private void btnResetLandTransfer_Click(object sender, EventArgs e)
        {
            txtPathToCccdLandTransfer.Clear();
            txtSaveFolderLandTransfer.Clear();
            txtErrorCCCDLandTransfer.Clear();
            chkInputIssuePlaceLandTransfer.Checked = false;
        }

        private void btnCancelLandTransfer_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCDLandTransfer, true);
            btnCancelLandTransfer.Enabled = false;
        }

        private async void btnScanLandTransfer_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccdLandTransfer.Text;
            string savePath = txtSaveFolderLandTransfer.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.GetDirectories(cccdPath).Any())
            {
                MessageBox.Show("Thư mục chứa cccd phải chứa thư mục con", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCDLandTransfer.Clear();

            try
            {
                var subDirs = Directory.GetDirectories(cccdPath);
                foreach (var dir in subDirs)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    string folderName = Path.GetFileName(dir);
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var images = Directory.GetFiles(dir)
                        .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
                        .ToList();

                    var sortedImages = images
                        .Select(f => {
                            string name = Path.GetFileNameWithoutExtension(f);
                            int underscoreIndex = name.IndexOf('_');
                            if (underscoreIndex > 0 && int.TryParse(name.Substring(0, underscoreIndex), out int idx))
                            {
                                return new { File = f, Index = idx };
                            }
                            return new { File = f, Index = -1 };
                        })
                        .OrderBy(x => x.Index)
                        .ToList();

                    if (sortedImages.Any(x => x.Index == -1))
                    {
                        string formatMsg = images.Count == 2 ? "1_{fileName}, 2_{fileName}" : "1_{fileName}, 2_{fileName}, 3_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Không thể đọc vì tên không đúng format. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandTransfer, true);
                        continue;
                    }

                    // Sequential check
                    bool validOrder = true;
                    for (int i = 0; i < sortedImages.Count; i++)
                    {
                        if (sortedImages[i].Index != i + 1)
                        {
                            validOrder = false;
                            break;
                        }
                    }

                    if (!validOrder)
                    {
                        string formatMsg = images.Count == 2 ? "1_{fileName}, 2_{fileName}" : "1_{fileName}, 2_{fileName}, 3_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Sai thứ tự index. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandTransfer, true);
                        continue;
                    }

                    List<CitizenData> results = new List<CitizenData>();
                    bool folderSuccess = true;

                    foreach (var imgItem in sortedImages)
                    {
                        if (_cts.Token.IsCancellationRequested) break;
                        try
                        {
                            var scanResult = await _cccdReaderService.ScanCccdAsync(imgItem.File);
                            if (scanResult != null && scanResult.Success && scanResult.Data != null)
                            {
                                results.Add(scanResult.Data);
                            }
                            else
                            {
                                LogAndSaveResult($"📁 {folderName} : Không thể đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandTransfer, true);
                                folderSuccess = false;
                                break;
                            }
                        }
                        catch
                        {
                            LogAndSaveResult($"📁 {folderName} : Lỗi khi đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandTransfer, true);
                            folderSuccess = false;
                            break;
                        }
                    }

                    if (!_cts.Token.IsCancellationRequested && folderSuccess && results.Count == images.Count)
                    {
                        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "land_transfer.docx");

                        if (!File.Exists(templatePath))
                        {
                            LogAndSaveResult($"📁 {folderName} : Không tìm thấy file template land_transfer.docx", logFilePath, txtErrorCCCDLandTransfer, true);
                            continue;
                        }

                        string outputFileName = $"{folderName}_{DateTime.Now:HHmmss}.docx";
                        string outputPath = Path.Combine(savePath, outputFileName);

                        Dictionary<int, string>? issuePlaces = null;
                        if (chkInputIssuePlaceLandTransfer.Checked)
                        {
                            var names = results.Select(r => r.FullName ?? "Không rõ tên").ToList();
                            using (var frm = new frmInputIssuePlace(names, chkInputIssuePlaceLandTransfer))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    issuePlaces = frm.IssuePlaces;
                                }
                                else
                                {
                                    // User cancelled the dialog, maybe stop or continue with dots?
                                    // Let's continue with dots (issuePlaces stays null)
                                }
                            }
                        }

                        FillLandTransferTemplate(templatePath, outputPath, results, issuePlaces);
                        LogAndSaveResult($"📁 {folderName} : Quét thành công và xuất file {outputFileName}", "", txtErrorCCCDLandTransfer);
                    }
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCDLandTransfer, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCDLandTransfer);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogAndSaveResult($"Lỗi nghiêm trọng: {ex.Message}", logFilePath, txtErrorCCCDLandTransfer, true);
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private async void btnScanDeligationPaper_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccdDeligationPaper.Text;
            string savePath = txtSaveFolderDeligationPaper.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.GetDirectories(cccdPath).Any())
            {
                MessageBox.Show("Thư mục chứa cccd phải chứa thư mục con", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCDDeligationPaper.Clear();

            try
            {
                var subDirs = Directory.GetDirectories(cccdPath);
                foreach (var dir in subDirs)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    string folderName = Path.GetFileName(dir);
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var images = Directory.GetFiles(dir)
                        .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
                        .ToList();

                    var sortedImages = images
                        .Select(f => {
                            string name = Path.GetFileNameWithoutExtension(f);
                            int underscoreIndex = name.IndexOf('_');
                            if (underscoreIndex > 0 && int.TryParse(name.Substring(0, underscoreIndex), out int idx))
                            {
                                return new { File = f, Index = idx };
                            }
                            return new { File = f, Index = -1 };
                        })
                        .OrderBy(x => x.Index)
                        .ToList();

                    if (sortedImages.Any(x => x.Index == -1))
                    {
                        string formatMsg = images.Count == 2 ? "1_{fileName}, 2_{fileName}" : "1_{fileName}, 2_{fileName}, 3_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Không thể đọc vì tên không đúng format. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDDeligationPaper, true);
                        continue;
                    }

                    // Sequential check
                    bool validOrder = true;
                    for (int i = 0; i < sortedImages.Count; i++)
                    {
                        if (sortedImages[i].Index != i + 1)
                        {
                            validOrder = false;
                            break;
                        }
                    }

                    if (!validOrder)
                    {
                        string formatMsg = images.Count == 2 ? "1_{fileName}, 2_{fileName}" : "1_{fileName}, 2_{fileName}, 3_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Sai thứ tự index. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDDeligationPaper, true);
                        continue;
                    }

                    List<CitizenData> results = new List<CitizenData>();
                    bool folderSuccess = true;

                    foreach (var imgItem in sortedImages)
                    {
                        if (_cts.Token.IsCancellationRequested) break;
                        try
                        {
                            var scanResult = await _cccdReaderService.ScanCccdAsync(imgItem.File);
                            if (scanResult != null && scanResult.Success && scanResult.Data != null)
                            {
                                results.Add(scanResult.Data);
                            }
                            else
                            {
                                LogAndSaveResult($"📁 {folderName} : Không thể đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDDeligationPaper, true);
                                folderSuccess = false;
                                break;
                            }
                        }
                        catch
                        {
                            LogAndSaveResult($"📁 {folderName} : Lỗi khi đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDDeligationPaper, true);
                            folderSuccess = false;
                            break;
                        }
                    }

                    if (!_cts.Token.IsCancellationRequested && folderSuccess && results.Count == images.Count)
                    {
                        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "delegation.docx");
                        if (!File.Exists(templatePath))
                        {
                            templatePath = @"d:\Project\CitizenIdentificationReading\Templates\delegation.docx";
                        }

                        if (!File.Exists(templatePath))
                        {
                            LogAndSaveResult($"📁 {folderName} : Không tìm thấy file template delegation.docx", logFilePath, txtErrorCCCDDeligationPaper, true);
                            continue;
                        }

                        string outputFileName = $"{folderName}_{DateTime.Now:HHmmss}.docx";
                        string outputPath = Path.Combine(savePath, outputFileName);

                        FillDelegationTemplate(templatePath, outputPath, results);
                        LogAndSaveResult($"📁 {folderName} : Quét thành công và xuất file {outputFileName}", "", txtErrorCCCDDeligationPaper);
                    }
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCDDeligationPaper, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCDDeligationPaper);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogAndSaveResult($"Lỗi nghiêm trọng: {ex.Message}", logFilePath, txtErrorCCCDDeligationPaper, true);
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void FillDelegationTemplate(string templatePath, string outputPath, List<CitizenData> users)
        {
            using (var document = DocX.Load(templatePath))
            {
                int count = users.Count;
                FillUserFields(document, "1", users[0]);

                if (count == 2)
                {
                    ClearUserFields(document, "2");
                    FillUserFields(document, "3", users[1]);
                }
                else if (count == 3)
                {
                    FillUserFields(document, "2", users[1]);
                    FillUserFields(document, "3", users[2]);
                }

                document.SaveAs(outputPath);
            }
        }

        private void FillLandTransferTemplate(string templatePath, string outputPath, List<CitizenData> users, Dictionary<int, string>? issuePlaces = null)
        {
            using (var document = DocX.Load(templatePath))
            {
                int count = users.Count;
                // Assuming land transfer always has at least 1 person
                FillUserFields(document, "1", users[0], issuePlaces?.ContainsKey(0) == true ? issuePlaces[0] : null, true);

                if (count >= 2)
                {
                    FillUserFields(document, "2", users[1], issuePlaces?.ContainsKey(1) == true ? issuePlaces[1] : null, true);
                }
                else
                {
                    ClearUserFields(document, "2");
                }

                if (count >= 3)
                {
                    FillUserFields(document, "3", users[2], issuePlaces?.ContainsKey(2) == true ? issuePlaces[2] : null, true);
                }
                else
                {
                    ClearUserFields(document, "3");
                }

                document.SaveAs(outputPath);
            }
        }

        private string FormatDateString(string? dateStr)
        {
            if (string.IsNullOrEmpty(dateStr)) return "..............................";

            // Try common formats: ddMMyyyy, yyyy-MM-dd, dd/MM/yyyy
            string[] formats = { "ddMMyyyy", "yyyy-MM-dd", "dd/MM/yyyy", "d/M/yyyy" };
            if (DateTime.TryParseExact(dateStr, formats, 
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dt))
            {
                return dt.ToString("dd/MM/yyyy");
            }

            return dateStr; // Fallback to original if parsing fails
        }

        private void FillUserFields(DocX document, string suffix, CitizenData user, string? issuePlace = null, bool upperCaseName = false)
        {
            string dots = "..............................";
            string fullName = user.FullName ?? dots;
            if (upperCaseName) fullName = fullName.ToUpper();

            document.ReplaceText("{{FullName" + suffix + "}}", fullName);
            document.ReplaceText("{{Dob" + suffix + "}}", FormatDateString(user.Dob));
            document.ReplaceText("{{CccdNumber" + suffix + "}}", user.CccdNumber ?? dots);
            document.ReplaceText("{{Address" + suffix + "}}", user.Address ?? dots);
            document.ReplaceText("{{IssueDate" + suffix + "}}", FormatDateString(user.IssueDate));
            document.ReplaceText("{{IssuePlace" + suffix + "}}", issuePlace ?? dots);
        }

        private void ClearUserFields(DocX document, string suffix)
        {
            string dots = "..............................";
            document.ReplaceText("{{FullName" + suffix + "}}", dots);
            document.ReplaceText("{{Dob" + suffix + "}}", dots);
            document.ReplaceText("{{CccdNumber" + suffix + "}}", dots);
            document.ReplaceText("{{Address" + suffix + "}}", dots);
            document.ReplaceText("{{IssueDate" + suffix + "}}", dots);
            document.ReplaceText("{{IssuePlace" + suffix + "}}", dots);
        }

        private void txtPathsLandChange_TextChanged(object sender, EventArgs e)
        {
            btnScanLandChange.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandChange.Text) &&
                                        !string.IsNullOrWhiteSpace(txtSaveFolderLandChange.Text);
        }

        private void btnSelectCCCDFolderLandChange_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccdLandChange.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolderLandChange_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolderLandChange.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnResetLandChange_Click(object sender, EventArgs e)
        {
            txtPathToCccdLandChange.Clear();
            txtSaveFolderLandChange.Clear();
            txtErrorCCCDLandChange.Clear();
            chkInputPhoneEmailLandChange.Checked = false;
        }

        private void btnCancelLandChange_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCDLandChange, true);
            btnCancelLandChange.Enabled = false;
        }

        private void FillLandChangeTemplate(string templatePath, string outputPath, List<CitizenData> users, Dictionary<int, string>? phones = null, Dictionary<int, string>? emails = null)
        {
            using (var document = DocX.Load(templatePath))
            {
                int count = users.Count;
                
                // Fill user fields for each person
                for (int i = 0; i < count; i++)
                {
                    string suffix = (i + 1).ToString();
                    FillUserFields(document, suffix, users[i], null, true);
                    
                    // Replace Phone and Email if provided
                    string dots = "..............................";
                    string phone = (phones != null && phones.ContainsKey(i) && !string.IsNullOrWhiteSpace(phones[i])) ? phones[i] : dots;
                    string email = (emails != null && emails.ContainsKey(i) && !string.IsNullOrWhiteSpace(emails[i])) ? emails[i] : dots;
                    
                    document.ReplaceText("{{PhoneNumber}}", phone);
                    document.ReplaceText("{{Email}}", email);
                }

                // Clear unused user fields for up to 2 users
                for (int i = count; i < 2; i++)
                {
                    string suffix = (i + 1).ToString();
                    ClearUserFields(document, suffix);
                    
                    string dots = "..............................";
                    document.ReplaceText("{{PhoneNumber}}", dots);
                    document.ReplaceText("{{Email}}", dots);
                }

                document.SaveAs(outputPath);
            }
        }

        private async void btnScanLandChange_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccdLandChange.Text;
            string savePath = txtSaveFolderLandChange.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.GetDirectories(cccdPath).Any())
            {
                MessageBox.Show("Thư mục chứa cccd phải chứa thư mục con", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCDLandChange.Clear();

            try
            {
                var subDirs = Directory.GetDirectories(cccdPath);
                foreach (var dir in subDirs)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    string folderName = Path.GetFileName(dir);
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var images = Directory.GetFiles(dir)
                        .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
                        .ToList();

                    if (images.Count == 0)
                    {
                        LogAndSaveResult($"📁 {folderName} : Không tìm thấy file ảnh", logFilePath, txtErrorCCCDLandChange, true);
                        continue;
                    }

                    if (images.Count > 2)
                    {
                        LogAndSaveResult($"📁 {folderName} : Vượt quá số lượng ảnh tối đa (tối đa 2 ảnh)", logFilePath, txtErrorCCCDLandChange, true);
                        continue;
                    }

                    var sortedImages = images
                        .Select(f => {
                            string name = Path.GetFileNameWithoutExtension(f);
                            int underscoreIndex = name.IndexOf('_');
                            if (underscoreIndex > 0 && int.TryParse(name.Substring(0, underscoreIndex), out int idx))
                            {
                                return new { File = f, Index = idx };
                            }
                            return new { File = f, Index = -1 };
                        })
                        .OrderBy(x => x.Index)
                        .ToList();

                    if (sortedImages.Any(x => x.Index == -1))
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Không thể đọc vì tên không đúng format. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandChange, true);
                        continue;
                    }

                    // Sequential check
                    bool validOrder = true;
                    for (int i = 0; i < sortedImages.Count; i++)
                    {
                        if (sortedImages[i].Index != i + 1)
                        {
                            validOrder = false;
                            break;
                        }
                    }

                    if (!validOrder)
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Sai thứ tự index. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandChange, true);
                        continue;
                    }

                    List<CitizenData> results = new List<CitizenData>();
                    bool folderSuccess = true;

                    foreach (var imgItem in sortedImages)
                    {
                        if (_cts.Token.IsCancellationRequested) break;
                        try
                        {
                            var scanResult = await _cccdReaderService.ScanCccdAsync(imgItem.File);
                            if (scanResult != null && scanResult.Success && scanResult.Data != null)
                            {
                                results.Add(scanResult.Data);
                            }
                            else
                            {
                                LogAndSaveResult($"📁 {folderName} : Không thể đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandChange, true);
                                folderSuccess = false;
                                break;
                            }
                        }
                        catch
                        {
                            LogAndSaveResult($"📁 {folderName} : Lỗi khi đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandChange, true);
                            folderSuccess = false;
                            break;
                        }
                    }

                    if (!_cts.Token.IsCancellationRequested && folderSuccess && results.Count == images.Count)
                    {
                        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "application_change_in_land.docx");
                        if (!File.Exists(templatePath))
                        {
                            templatePath = @"d:\Project\CitizenIdentificationReading\Templates\application_change_in_land.docx";
                        }

                        if (!File.Exists(templatePath))
                        {
                            LogAndSaveResult($"📁 {folderName} : Không tìm thấy file template application_change_in_land.docx", logFilePath, txtErrorCCCDLandChange, true);
                            continue;
                        }

                        string outputFileName = $"{folderName}_{DateTime.Now:HHmmss}.docx";
                        string outputPath = Path.Combine(savePath, outputFileName);

                        Dictionary<int, string>? phones = null;
                        Dictionary<int, string>? emails = null;

                        if (chkInputPhoneEmailLandChange.Checked)
                        {
                            var names = results.Select(r => r.FullName ?? "Không rõ tên").ToList();
                            using (var frm = new frmInputPhoneNumberMailChangeInlandApplication(names, chkInputPhoneEmailLandChange))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    phones = frm.PhoneNumbers;
                                    emails = frm.Emails;
                                }
                                else
                                {
                                    // User cancelled
                                }
                            }
                        }

                        FillLandChangeTemplate(templatePath, outputPath, results, phones, emails);
                        LogAndSaveResult($"📁 {folderName} : Quét thành công và xuất file {outputFileName}", "", txtErrorCCCDLandChange);
                    }
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCDLandChange, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCDLandChange);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogAndSaveResult($"Lỗi nghiêm trọng: {ex.Message}", logFilePath, txtErrorCCCDLandChange, true);
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        public void FillWordTemplate(string templatePath, string outputPath, CitizenData userData)
        {
            // Mở file template
            using (var document = DocX.Load(templatePath))
            {
                // Thực hiện thay thế các placeholder
                document.ReplaceText("{{FullName}}", userData.FullName ?? "");
                document.ReplaceText("{{Address}}", userData.Address ?? "");
                document.ReplaceText("{{CccdNumber}}", userData.CccdNumber ?? "");
                document.ReplaceText("{{OldID}}", userData.OldId ?? "");
                document.ReplaceText("{{DOB}}", FormatDateString(userData.Dob));
                document.ReplaceText("{{Gender}}", userData.Gender ?? "");
                document.ReplaceText("{{IssueDate}}", FormatDateString(userData.IssueDate));

                // Lưu thành file mới
                document.SaveAs(outputPath);
            }
        }

        private void txtPathsLandUseChange_TextChanged(object sender, EventArgs e)
        {
            btnScanLandUseChange.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdLandUseChange.Text) &&
                                           !string.IsNullOrWhiteSpace(txtSaveFolderLandUseChange.Text);
        }

        private void btnSelectCCCDFolderLandUseChange_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccdLandUseChange.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolderLandUseChange_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolderLandUseChange.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnResetLandUseChange_Click(object sender, EventArgs e)
        {
            txtPathToCccdLandUseChange.Clear();
            txtSaveFolderLandUseChange.Clear();
            txtErrorCCCDLandUseChange.Clear();
            chkInputContactLandUseChange.Checked = false;
        }

        private void btnCancelLandUseChange_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCDLandUseChange, true);
            btnCancelLandUseChange.Enabled = false;
        }

        private void FillLandUseChangeTemplate(string templatePath, string outputPath, List<CitizenData> users, string contactInfo = "")
        {
            using (var document = DocX.Load(templatePath))
            {
                int count = users.Count;
                
                // Fill user fields for each person
                for (int i = 0; i < count; i++)
                {
                    string suffix = (i + 1).ToString();
                    FillUserFields(document, suffix, users[i], null, true);
                }

                // Clear unused user fields for up to 2 users
                for (int i = count; i < 2; i++)
                {
                    string suffix = (i + 1).ToString();
                    ClearUserFields(document, suffix);
                }

                // Populate Contact Placeholder
                string dots = "..................................................";
                string contact = (!string.IsNullOrWhiteSpace(contactInfo)) ? contactInfo : dots;
                document.ReplaceText("{{Contact}}", contact);

                document.SaveAs(outputPath);
            }
        }

        private async void btnScanLandUseChange_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccdLandUseChange.Text;
            string savePath = txtSaveFolderLandUseChange.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.GetDirectories(cccdPath).Any())
            {
                MessageBox.Show("Thư mục chứa cccd phải chứa thư mục con", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCDLandUseChange.Clear();

            try
            {
                var subDirs = Directory.GetDirectories(cccdPath);
                foreach (var dir in subDirs)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    string folderName = Path.GetFileName(dir);
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var images = Directory.GetFiles(dir)
                        .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
                        .ToList();

                    if (images.Count == 0)
                    {
                        LogAndSaveResult($"📁 {folderName} : Không tìm thấy file ảnh", logFilePath, txtErrorCCCDLandUseChange, true);
                        continue;
                    }

                    if (images.Count > 2)
                    {
                        LogAndSaveResult($"📁 {folderName} : Vượt quá số lượng ảnh tối đa (tối đa 2 ảnh)", logFilePath, txtErrorCCCDLandUseChange, true);
                        continue;
                    }

                    var sortedImages = images
                        .Select(f => {
                            string name = Path.GetFileNameWithoutExtension(f);
                            int underscoreIndex = name.IndexOf('_');
                            if (underscoreIndex > 0 && int.TryParse(name.Substring(0, underscoreIndex), out int idx))
                            {
                                return new { File = f, Index = idx };
                            }
                            return new { File = f, Index = -1 };
                        })
                        .OrderBy(x => x.Index)
                        .ToList();

                    if (sortedImages.Any(x => x.Index == -1))
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Không thể đọc vì tên không đúng format. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandUseChange, true);
                        continue;
                    }

                    // Sequential check
                    bool validOrder = true;
                    for (int i = 0; i < sortedImages.Count; i++)
                    {
                        if (sortedImages[i].Index != i + 1)
                        {
                            validOrder = false;
                            break;
                        }
                    }

                    if (!validOrder)
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Sai thứ tự index. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDLandUseChange, true);
                        continue;
                    }

                    List<CitizenData> results = new List<CitizenData>();
                    bool folderSuccess = true;

                    foreach (var imgItem in sortedImages)
                    {
                        if (_cts.Token.IsCancellationRequested) break;
                        try
                        {
                            var scanResult = await _cccdReaderService.ScanCccdAsync(imgItem.File);
                            if (scanResult != null && scanResult.Success && scanResult.Data != null)
                            {
                                results.Add(scanResult.Data);
                            }
                            else
                            {
                                LogAndSaveResult($"📁 {folderName} : Không thể đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandUseChange, true);
                                folderSuccess = false;
                                break;
                            }
                        }
                        catch
                        {
                            LogAndSaveResult($"📁 {folderName} : Lỗi khi đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDLandUseChange, true);
                            folderSuccess = false;
                            break;
                        }
                    }

                    if (!_cts.Token.IsCancellationRequested && folderSuccess && results.Count == images.Count)
                    {
                        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "application_land_use_change.docx");
                        if (!File.Exists(templatePath))
                        {
                            templatePath = @"d:\Project\CitizenIdentificationReading\Templates\application_land_use_change.docx";
                        }

                        if (!File.Exists(templatePath))
                        {
                            LogAndSaveResult($"📁 {folderName} : Không tìm thấy file template application_land_use_change.docx", logFilePath, txtErrorCCCDLandUseChange, true);
                            continue;
                        }

                        string outputFileName = $"{folderName}_{DateTime.Now:HHmmss}.docx";
                        string outputPath = Path.Combine(savePath, outputFileName);

                        string contactVal = "";

                        if (chkInputContactLandUseChange.Checked)
                        {
                            var names = results.Select(r => r.FullName ?? "Không rõ tên").ToList();
                            using (var frm = new frmInputContactLandUseChange(names, chkInputContactLandUseChange))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    contactVal = frm.ContactText;
                                }
                            }
                        }

                        FillLandUseChangeTemplate(templatePath, outputPath, results, contactVal);
                        LogAndSaveResult($"📁 {folderName} : Quét thành công và xuất file {outputFileName}", "", txtErrorCCCDLandUseChange);
                    }
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCDLandUseChange, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCDLandUseChange);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogAndSaveResult($"Lỗi nghiêm trọng: {ex.Message}", logFilePath, txtErrorCCCDLandUseChange, true);
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void txtPathsAttachedLand_TextChanged(object sender, EventArgs e)
        {
            btnScanAttachedLand.Enabled = !string.IsNullOrWhiteSpace(txtPathToCccdAttachedLand.Text) &&
                                          !string.IsNullOrWhiteSpace(txtSaveFolderAttachedLand.Text);
        }

        private void btnSelectCCCDFolderAttachedLand_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPathToCccdAttachedLand.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSaveFolderAttachedLand_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSaveFolderAttachedLand.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnResetAttachedLand_Click(object sender, EventArgs e)
        {
            txtPathToCccdAttachedLand.Clear();
            txtSaveFolderAttachedLand.Clear();
            txtErrorCCCDAttachedLand.Clear();
            chkInputPhoneEmailAttachedLand.Checked = false;
        }

        private void btnCancelAttachedLand_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            LogAndSaveResult("Đã gửi yêu cầu hủy quét...", "", txtErrorCCCDAttachedLand, true);
            btnCancelAttachedLand.Enabled = false;
        }

        private void FillAttachedLandTemplate(string templatePath, string outputPath, List<CitizenData> users, string phone = "", string email = "")
        {
            using (var document = DocX.Load(templatePath))
            {
                int count = users.Count;
                
                // Fill user fields for each person
                for (int i = 0; i < count; i++)
                {
                    string suffix = (i + 1).ToString();
                    FillUserFields(document, suffix, users[i], null, false);
                }

                // Clear unused user fields for up to 2 users
                for (int i = count; i < 2; i++)
                {
                    string suffix = (i + 1).ToString();
                    ClearUserFields(document, suffix);
                }

                // Populate Phone and Email Placeholders
                string dots = "........................................";
                string phoneInfo = !string.IsNullOrWhiteSpace(phone) ? phone : dots;
                string emailInfo = !string.IsNullOrWhiteSpace(email) ? email : dots;
                document.ReplaceText("{{PhoneNumber}}", phoneInfo);
                document.ReplaceText("{{Email}}", emailInfo);

                document.SaveAs(outputPath);
            }
        }

        private async void btnScanAttachedLand_Click(object sender, EventArgs e)
        {
            string cccdPath = txtPathToCccdAttachedLand.Text;
            string savePath = txtSaveFolderAttachedLand.Text;

            if (!Directory.Exists(cccdPath))
            {
                MessageBox.Show("Folder chứa cccd không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(savePath))
            {
                MessageBox.Show("Folder lưu kết quả không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.GetDirectories(cccdPath).Any())
            {
                MessageBox.Show("Thư mục chứa cccd phải chứa thư mục con", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.Equals(Path.GetFullPath(cccdPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              Path.GetFullPath(savePath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                              StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Folder lưu kết quả không được trùng với folder chứa cccd", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _cts = new CancellationTokenSource();
            string logFilePath = Path.Combine(savePath, $"log_{DateTime.Now:ddMMyyyyHHmmss}.txt");
            SetProcessingState(true);
            txtErrorCCCDAttachedLand.Clear();

            try
            {
                var subDirs = Directory.GetDirectories(cccdPath);
                foreach (var dir in subDirs)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    string folderName = Path.GetFileName(dir);
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var images = Directory.GetFiles(dir)
                        .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLower()))
                        .ToList();

                    if (images.Count == 0)
                    {
                        LogAndSaveResult($"📁 {folderName} : Không tìm thấy file ảnh", logFilePath, txtErrorCCCDAttachedLand, true);
                        continue;
                    }

                    if (images.Count > 2)
                    {
                        LogAndSaveResult($"📁 {folderName} : Vượt quá số lượng ảnh tối đa (tối đa 2 ảnh)", logFilePath, txtErrorCCCDAttachedLand, true);
                        continue;
                    }

                    var sortedImages = images
                        .Select(f => {
                            string name = Path.GetFileNameWithoutExtension(f);
                            int underscoreIndex = name.IndexOf('_');
                            if (underscoreIndex > 0 && int.TryParse(name.Substring(0, underscoreIndex), out int idx))
                            {
                                return new { File = f, Index = idx };
                            }
                            return new { File = f, Index = -1 };
                        })
                        .OrderBy(x => x.Index)
                        .ToList();

                    if (sortedImages.Any(x => x.Index == -1))
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Không thể đọc vì tên không đúng format. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDAttachedLand, true);
                        continue;
                    }

                    // Sequential check
                    bool validOrder = true;
                    for (int i = 0; i < sortedImages.Count; i++)
                    {
                        if (sortedImages[i].Index != i + 1)
                        {
                            validOrder = false;
                            break;
                        }
                    }

                    if (!validOrder)
                    {
                        string formatMsg = "1_{fileName} hoặc 1_{fileName}, 2_{fileName}";
                        LogAndSaveResult($"📁 {folderName} : Sai thứ tự index. Bạn cần sửa lại {formatMsg}", logFilePath, txtErrorCCCDAttachedLand, true);
                        continue;
                    }

                    List<CitizenData> results = new List<CitizenData>();
                    bool folderSuccess = true;

                    foreach (var imgItem in sortedImages)
                    {
                        if (_cts.Token.IsCancellationRequested) break;
                        try
                        {
                            var scanResult = await _cccdReaderService.ScanCccdAsync(imgItem.File);
                            if (scanResult != null && scanResult.Success && scanResult.Data != null)
                            {
                                results.Add(scanResult.Data);
                            }
                            else
                            {
                                LogAndSaveResult($"📁 {folderName} : Không thể đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDAttachedLand, true);
                                folderSuccess = false;
                                break;
                            }
                        }
                        catch
                        {
                            LogAndSaveResult($"📁 {folderName} : Lỗi khi đọc ảnh {Path.GetFileName(imgItem.File)}", logFilePath, txtErrorCCCDAttachedLand, true);
                            folderSuccess = false;
                            break;
                        }
                    }

                    if (!_cts.Token.IsCancellationRequested && folderSuccess && results.Count == images.Count)
                    {
                        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "application_attached_land.docx");
                        if (!File.Exists(templatePath))
                        {
                            templatePath = @"d:\Project\CitizenIdentificationReading\Templates\application_attached_land.docx";
                        }

                        if (!File.Exists(templatePath))
                        {
                            LogAndSaveResult($"📁 {folderName} : Không tìm thấy file template application_attached_land.docx", logFilePath, txtErrorCCCDAttachedLand, true);
                            continue;
                        }

                        string outputFileName = $"{folderName}_{DateTime.Now:HHmmss}.docx";
                        string outputPath = Path.Combine(savePath, outputFileName);

                        string phoneVal = "";
                        string emailVal = "";

                        if (chkInputPhoneEmailAttachedLand.Checked)
                        {
                            var names = results.Select(r => r.FullName ?? "Không rõ tên").ToList();
                            using (var frm = new frmInputMailAndPhoneNumberAttachedLand(names, chkInputPhoneEmailAttachedLand))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    phoneVal = frm.PhoneNumber;
                                    emailVal = frm.Email;
                                }
                            }
                        }

                        FillAttachedLandTemplate(templatePath, outputPath, results, phoneVal, emailVal);
                        LogAndSaveResult($"📁 {folderName} : Quét thành công và xuất file {outputFileName}", "", txtErrorCCCDAttachedLand);
                    }
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    LogAndSaveResult("Quá trình quét đã bị hủy.", logFilePath, txtErrorCCCDAttachedLand, true);
                }
                else
                {
                    LogAndSaveResult("Hoàn tất quá trình quét.", "", txtErrorCCCDAttachedLand);
                    MessageBox.Show("Hoàn tất quá trình quét!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogAndSaveResult($"Lỗi nghiêm trọng: {ex.Message}", logFilePath, txtErrorCCCDAttachedLand, true);
            }
            finally
            {
                SetProcessingState(false);
                _cts?.Dispose();
                _cts = null;
            }
        }
    }

    public class ScanQrResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public CitizenData? Data { get; set; }
    }

    public class CitizenData
    {
        [JsonPropertyName("cccd_number")]
        public string? CccdNumber { get; set; }

        [JsonPropertyName("old_id")]
        public string? OldId { get; set; }

        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }

        [JsonPropertyName("dob")]
        public string? Dob { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("issue_date")]
        public string? IssueDate { get; set; }

        public override string ToString()
        {
            return $"Số CCCD: {CccdNumber}{Environment.NewLine}" +
                   $"Số CMND cũ: {OldId}{Environment.NewLine}" +
                   $"Họ tên: {FullName}{Environment.NewLine}" +
                   $"Ngày sinh: {Dob}{Environment.NewLine}" +
                   $"Giới tính: {Gender}{Environment.NewLine}" +
                   $"Địa chỉ: {Address}{Environment.NewLine}" +
                   $"Ngày cấp: {IssueDate}";
        }
    }
}
