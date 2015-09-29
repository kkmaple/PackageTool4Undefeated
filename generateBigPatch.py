# coding=gbk
import time
import ConfigParser
import shutil
import os
import hashlib
import wx
from xml.etree import ElementTree
import xml.dom.minidom as minidom

def step1(conf):
    respath = conf.get('resource','resource_path')
    ostype = conf.get('os','os')
    fatherpath = os.path.dirname(respath)
    if ostype == '1' or ostype == '2' :
        checkpath = os.path.join(fatherpath,'Media_pvr')
        if os.path.exists(checkpath):
            shutil.move(checkpath,checkpath + '_' + str(time.strftime("%Y_%m_%d_%H_%M_%S", time.localtime())))
            #print ''
    elif ostype == '3' :
        checkpath = os.path.join(fatherpath,'Media_etc1')
        if os.path.exists(checkpath):
            shutil.move(checkpath,checkpath + '_' + str(time.strftime("%Y_%m_%d_%H_%M_%S", time.localtime())))
            #print ''
    os.system(os.path.join(fatherpath,'Tools\PVRUtil\PVRUtil.exe'))
    if ostype == '1' or ostype == '2' :
        os.system("cd " + fatherpath + " && " + os.path.join(fatherpath,'''压缩PVR之后执行.bat'''))

def step2(conf):
    respath = conf.get('resource','resource_path')
    ostype = conf.get('os','os')
    fatherpath = os.path.dirname(respath)
    ver = conf.get('version','ver')
    checkpath = os.path.join(fatherpath,'Media_pvr')
    if ostype == '3' :
        checkpath = os.path.join(fatherpath,'Media_etc1')
    innerfolder1 = os.path.join(checkpath,ver)
    innerfolder2 = os.path.join(innerfolder1,'resource')
    innerfolder3 = os.path.join(innerfolder2,'Media')
    os.mkdir(innerfolder1)
    os.mkdir(innerfolder2)
    shutil.move(os.path.join(checkpath,'Sound'),os.path.join(innerfolder2,'Sound'))
    shutil.move(os.path.join(checkpath,'Fonts'),os.path.join(innerfolder2,'Fonts'))
    for root,dirs,files in os.walk(checkpath) :
        for dir in dirs :
            if ver + '_app' == dir :
                continue
            if ver + '_ios' == dir :
                continue
            if ver + '_android' == dir :
                continue
            if ver == dir :
                continue
            shutil.move(os.path.join(checkpath,dir),os.path.join(innerfolder3,dir))
        break
    shutil.copy(os.path.join(fatherpath,'version.xml'),os.path.join(innerfolder1,'version.xml'))
    if os.path.exists(os.path.join(fatherpath,'resource_online.cfg')):
        shutil.copy(os.path.join(fatherpath,'resource_online.cfg'),os.path.join(innerfolder2,'resource.cfg'))
    else:
        print 'failed to copy resource.cfg'
    shutil.copy(os.path.join(fatherpath,'ClientCfg.xml'),os.path.join(innerfolder2,'ClientCfg.xml'))
    shutil.copy(os.path.join(fatherpath,'engine.xml'),os.path.join(innerfolder2,'engine.xml'))
    shutil.copy(os.path.join(fatherpath,'scrsize.txt'),os.path.join(innerfolder2,'scrsize.txt'))
    step3(conf,innerfolder1)

def step3(conf,innerfolder1) :
    respath = conf.get('resource','resource_path')
    ostype = conf.get('os','os')
    fatherpath = os.path.dirname(respath)
    ver = conf.get('version','ver')
    cf = ConfigParser.ConfigParser() 
    cf.read('pkgconf.ini')
    cf.set('init_value','xmlbasever',ver)
    cf.set('init_value','current_base',ver)
    cf.remove_section('resource_list')
    cf.write(open('pkgconf-trunk.ini','w'))
    os.system('cd restmd5xt && del /f /q *.txt')
    os.system('file_generator.py')
    shutil.copy(os.path.join("restmd5xt/",ver+'.txt'),os.path.join(innerfolder1,ver+'.txt'))
    os.system('zstgot.py')
    shutil.move('resource.zst',os.path.join(innerfolder1,'resource.zst'))
    change_verxml(os.path.join(innerfolder1,'version.xml'),md5_file(os.path.join(innerfolder1,'resource.zst')),ver,ver,ver)
    os.system(os.path.join(fatherpath,'Tools\ZLibTool.exe'))
    shutil.move('.\Paks\Media.pak',os.path.join(innerfolder1,'Media_' + ver + '.pak'))
    pakmd5file = open(os.path.join(innerfolder1,'Media_' + ver + '.zs5'),'wt')
    pakmd5file.write(md5_file(os.path.join(innerfolder1,'Media_' + ver + '.pak')))
    pakmd5file.close()

def change_verxml(path,newvalue,version,basis,lowver):
    xmldoc = ElementTree.parse(path)
    root = xmldoc.getroot()
    node = xmldoc.findall('Property')
    for e in xmldoc.findall('Property'):
        if e.attrib and e.attrib["name"] == "data":
            e.attrib["value"] = newvalue
        if e.attrib and e.attrib["name"] == "version":
            e.attrib["value"] = version
        if e.attrib and e.attrib["name"] == "basis":
            e.attrib["value"] = basis
        if e.attrib and e.attrib["name"] == "lowver":
            e.attrib["value"] = lowver
    xmldoc.write(path,"utf-8")

def md5_file(name):
    m = hashlib.md5()
    a_file = open(name, 'rb')
    m.update(a_file.read())
    a_file.close()
    return m.hexdigest()

def main():
    print '''Generate Big Patch Start!!!'''
    conf = ConfigParser.ConfigParser()
    conf.read('bigPatch.ini')
    step1(conf)
    step2(conf)
    print '''All Done!!!'''
    time.sleep(1)

if __name__=="__main__":	
    main()
