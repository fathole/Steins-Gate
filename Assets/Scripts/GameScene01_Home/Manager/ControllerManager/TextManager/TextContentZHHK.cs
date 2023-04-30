using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene
{
    public class TextContentZHHK : TextContentBase
    {
        public TextContentZHHK()
        {
            #region Home Page

            homePage = new HomePage
            {
                uDEHeader = new HomePage.UDEHeader
                {
                    text001 = "�A��Ө�o��,���O�R�B�ۤ��������!",
                },
                oDEGalleryButton = new HomePage.ODEGalleryButton
                {
                    text001 = "����",
                },
                oDEMusicButton = new HomePage.ODEMusicButton
                {
                    text001 = "����",
                },
                oDESentenceButton = new HomePage.ODESentenceButton
                {
                    text001 = "�y��",
                },
                oDEIntroButton = new HomePage.ODEIntroButton
                {
                    text001 = "²��",
                },
            };

            #endregion

            #region Gallery Page

            galleryPage = new GalleryPage
            {
                oDEScopeButtonList = new GalleryPage.ODEScopeButtonList
                {
                    steinsGateButtonContentText001 = "SG",
                    steinsGate0ButtonContentText001 = "SG0",
                    steinsGatePhenogramContentText001 = "SGP",
                    steinsGateDaringButtonnContentText001 = "SGD",
                    pixivButtonContentText001 = "Pixiv",
                    otherButtonContentText001 = "��L",
                }
            };

            #endregion

            #region Music Page

            musicPage = new MusicPage
            {
                oDEMusicScrollViewMusicSlot = new MusicPage.ODEMusicScrollViewMusicSlot
                {
                    contentMusicNameText001 = "{0}",
                    contentMusicLengthText001 = "{0}:{1}",
                },
                oDESearchDataEntry = new MusicPage.ODESearchDataEntry
                {
                    searchInputFieldPlaceHolderText001 = "��J�W�٥H�j�M",
                },
                oDEMusicControlBar = new MusicPage.ODEMusicControlBar
                {
                    musicNameText001 = "{0}",
                    progressBarCurrentTimeText001 = "{0}:{1}",
                    progressBarTotalTimeText001 = "{0}:{1}",

                    selectSongNotice = "�����",
                },
                oDESortingButton = new MusicPage.ODESortingButton
                {
                    contentText001 = "�Ƨ�",
                },
                oDESortingPanal = new MusicPage.ODESortingPanal
                {
                    panelContentLengthButtonContentText001 = "����",
                    panelContentNameButtonContentText001 = "�W��",
                },
            };

            #endregion

            #region Sentence Page

            sentencePage = new SentencePage
            {
                sentenceList = new List<SentencePage.UDESentenceScrollViewSentenceSlot>
                {
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�N�⪾�D��k�A�]���藍��h���ܹL�h�A������N�s�b���i������ܬ��J�w���{��A���ӬO�S���H��w�����A�O�L�k���Ӫ��A���]�p���H�̤~�౵���U�صh�W�A�����P���Ӿ�סA�ڨB�e�i�C",
                        contentSpeakerText001 = "�����ۤӭ�",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "���Ӫ��Ʊ��A�֤]�����D�C���]���p���A�N�p�P�A���ۨ������A���Ӥ~���L�����i��C",
                        contentSpeakerText001 = "�R�B�ۤ���",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "���n�Q�@�������ܲ{�b�A�o�u�|���L�h�ܱo�ѥإ��D�}�F�C",
                        contentSpeakerText001 = "�R�B�ۤ���",
                    },
                  new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�ɶ����֪��y�u�A�߿W�{�b�A�ڦ��@�طQ��R�]���Z�o�c�̪��߱��A�����A�ɶ��ھڨC�ӤH���D�[�P���A�J�|�ܪ��A�]�|�ܵu�A�۹�ׯu�O�J�����S�˷P���F��O�C",
                        contentSpeakerText001 = "���u������",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�t�z������_���A�o�S���׵��X�X�L���C�P�y���]���_���A�o�]��ۨ����O���V�����X�X�����C�֦��ʹ����~�O�̬��M���̡A���v�W���ӪT�|...�o�]�i�H���O�����ǩ�ܪ̭̪��A�����̫�q�ޡC�C",
                        contentSpeakerText001 = "�R�B�ۤ���",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "El Psy Congroo",
                        contentSpeakerText001 = "�����ۤӭ�",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�L�h�b�����A���ӬO�_�N��?���b�a��C",
                        contentSpeakerText001 = "�R�B�ۤ���",
                    },
                      new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�H���`�O�|����?�ۤv�Ҭõ����F��A�߿W�S���ۤv",
                        contentSpeakerText001 = "���u������",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�A�H���u���ۤv�@�ӤH�b�伵?�o�ӥ@�ɶܡH�ۥH���O�]�n���ӭ��סA���n�ѰO�A���ާA���B���@���@�ɽu�A�A�����|�t�W�C�L�קA���B���A�ڳ��|���A�A�ڷ|�@���[��?�A�A�N���A�@���H���[��?�ڤ@�ˡC",
                        contentSpeakerText001 = "���u������",
                    },
                     new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "���]���کM�A�@�_�׹L�F���Ǥ�l�A�ҥH�~���աA�L�ר��B������@�ɽu�W�����Ӯɶ��A���Ӧa�I�A�ڳ����w?�A�C�ڦA���@���A���u�����ϡA�ڳ��w�A�A���A�O�H���ɦ���A�A�O�p��ݫݧڪ��C",
                        contentSpeakerText001 = "�����ۤӭ�",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�ڴ��g�ݹL�o������n��D�˫D�G���ڳo��n�A�M�ᨺ�ӤH��?�o�򻡤F�A�ɥ��y��A�H�`�O�b�L�H�����U�U�ͬ�?�A�ҥH�`���@�ѧA�]�n���U�O�H�ڡC",
                        contentSpeakerText001 = "�Ѥ��x�Χ^",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�ڬO�g�𪺬�Ǯa�A��İ|���u�C���F�@�ɳo�ؤp�ơA���Ȥ@���I",
                        contentSpeakerText001 = "��İ|���u",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�@�ɴN�b�ڴx���C",
                        contentSpeakerText001 = "��İ|���u",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�Ҧ����@�ɦܲz�����L�O�ϰϤ����A���M�s�b?�Ѫk�C",
                        contentSpeakerText001 = "�u�|",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�����쪺��......�M�u�Ѳz���ɭԬO�@�˪��A���װ��X��˪��òϡA�����Ϥ@�w�|���h�C������H�~���ѤF�@���Ӥw�I�@���I�O�}�����F�C�A�H���ڥ��ѤF�X���A�X�Q���ڡI�ڬO���D���ڡA�o�ӥ@�ɪ��]�G�ߪ����X�z�ʡC�b�e�赥��?���A�N�|�O�h��d�G�������C�ڪ��D���ڡA�ڡA�w�g�֤F�A�w�g�֤F�ڡC",
                        contentSpeakerText001 = "�����ۤӭ�",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�b�L�Ʊ��@�ɽu���A�����w�|�s�b��L���u�ڡv�A�L�ƪ��u�ڡv�߷N�۳q�A�䤤�����w�N�]�t?�ڡC",
                        contentSpeakerText001 = "���u������",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�b����ɭԡA������ҳ��s�b?�ڡA�`�R�Y�H���`�����P���A�۫H�Y�ƪ���j���P���A�Q�n�ǻ����򪺱j�P������A��V�ɶ��A�ۤ��p�t�A�~�Φ��F�{�b���ڪ��ܡA���ٯu�O�D�`�������Ʊ��ڡI",
                        contentSpeakerText001 = "���u������",
                    },
                    new SentencePage.UDESentenceScrollViewSentenceSlot
                    {
                        contentSentenceText001 = "�@�����O�R�B�ۤ�������ܡC",
                        contentSpeakerText001 = "�����ۤӭ�",
                    },
                },
                uDETitle = new SentencePage.UDETitle
                {
                    text001 = "�y��",
                }
            };

            #endregion

            /* ----- Large Popup ----- */

            #region Sentence Popup

            sentencePopup = new GameManager.TextContentBase.LargePopup
            {
                uDETitle = new GameManager.TextContentBase.LargePopup.UDETitle
                {
                    text001 = "�y��"
                },
                uDEContent = new GameManager.TextContentBase.LargePopup.UDEContent
                {
                    text001 = "�y�l:\n{0}\n\n �ӷ�:\n{1}"
                },
                oDEPrimaryButton = new GameManager.TextContentBase.LargePopup.ODEPrimaryButton
                {
                    contentText001 = "����"
                },
            };

            #endregion

            /* ----- Small Popup ----- */

            #region Coming Soon Popup

            comingSoonPopup = new GameManager.TextContentBase.SmallPopup
            {
                uDETitle = new GameManager.TextContentBase.SmallPopup.UDETitle
                {
                    text001 = "�|���}��",
                },
                oDEPrimaryButton = new GameManager.TextContentBase.SmallPopup.ODEPrimaryButton
                {
                    contentText001 = "�T�w",
                },
            };

            #endregion
        }
    }
}