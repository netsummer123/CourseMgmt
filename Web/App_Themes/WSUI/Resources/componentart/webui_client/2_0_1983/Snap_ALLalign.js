function art_AnimateSpan(qzaz,qzAke,qzAkd){var qzg=art_GetInstance(qzaz),qzq=qzg.Frame,qzAel=parseInt(qzq.style.left),qzAek=parseInt(qzq.style.top),qzAhu=qzAel+Math.round((qzAke-qzAel)/4),qzAht=qzAek+Math.round((qzAkd-qzAek)/4);if(qzAhu!=qzAel||qzAht!=qzAek){if(qzg.AlignAnimationTimer){clearTimeout(qzg.AlignAnimationTimer);qzg.AlignAnimationTimer=null;};qzg.AlignAnimationTimer=setTimeout('art_AnimateSpan(\''+qzaz+'\','+qzAke+','+qzAkd+')',5);}else{qzAhu=qzAke;qzAht=qzAkd;qzgb(qzaz,qzAhu,qzAht,qzq.offsetWidth,qzq.offsetHeight);};qzq.style.left=qzAhu;qzq.style.top=qzAht;};function art_PositionSpan(qzaz,qzvc,qzxb,qzAad,offsetX,offsetY,qzAmf){var qzg=art_GetInstance(qzaz),qzq=qzg.Frame,qzoz=qzq.offsetWidth,qzmt=qzq.offsetHeight,qzkh=qzow?window.document.body.scrollLeft:self.pageXOffset;var qzlz=qzow?window.document.body.scrollTop:self.pageYOffset;var qzxd=qzow?window.document.body.clientWidth:self.innerWidth-16,qzxc=qzow?window.document.body.clientHeight:self.innerHeight-10,qzfc=0,qzgg=0;switch(qzvc){case'TopLeft':qzfc=qzkh;qzgg=qzlz;break;case'TopCentre':qzfc=(qzxd-qzoz)/2+qzkh;qzgg=qzlz;break;case'TopRight':qzfc=qzxd+qzkh-qzoz;qzgg=qzlz;break;case'BottomLeft':qzfc=qzkh;qzgg=qzxc+qzlz-qzmt;break;case'BottomCentre':qzfc=(qzxd-qzoz)/2+qzkh;qzgg=qzxc+qzlz-qzmt;break;case'BottomRight':qzfc=qzxd+qzkh-qzoz;qzgg=qzxc+qzlz-qzmt;break;case'MiddleLeft':qzfc=qzkh;qzgg=qzxc/2+qzlz-qzmt;break;case'MiddleCentre':qzfc=(qzxd-qzoz)/2+qzkh;qzgg=qzxc/2+qzlz-qzmt;break;case'MiddleRight':qzfc=qzxd+qzkh-qzoz;qzgg=qzxc/2+qzlz-qzmt;break;default:qzfc=qzkh;qzgg=qzlz;break;};qzfc+=offsetX;qzgg+=offsetY;if(qzfc<qzxb){qzfc=qzxb;};if(qzgg<qzAad){qzgg=qzAad;};if(qzAmf){art_AnimateSpan(qzg.Id,qzfc,qzgg);}else{qzq.style.left=qzfc;qzq.style.top=qzgg;};qzgb(qzg,qzfc,qzgg,qzoz,qzmt);};