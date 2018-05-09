// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface CustomTableViewCell : UITableViewCell {
	UILabel *_TxtFavs;
	UILabel *_TxtRetweets;
	UILabel *_TxtTweet;
}

@property (nonatomic, retain) IBOutlet UILabel *TxtFavs;

@property (nonatomic, retain) IBOutlet UILabel *TxtRetweets;

@property (nonatomic, retain) IBOutlet UILabel *TxtTweet;
@property (weak, nonatomic) IBOutlet UISearchBar *SrchTweet;

@end
