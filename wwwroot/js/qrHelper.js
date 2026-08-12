window.downloadByteArrayFile = (base64Data, fileName) => {
    const link = document.createElement('a');
    link.href = 'data:application/pdf;base64,' + base64Data;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};